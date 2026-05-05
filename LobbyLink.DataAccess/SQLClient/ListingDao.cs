using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LobbyLink.DataAccess.SQLClient;

public class ListingDao : BaseDao, IFListingDao
{
    public ListingDao(string connectionString) : base(connectionString) { }

    public IEnumerable<Listing> GetAllActiveListings()
    {
        using var connection = CreateConnection();

        try
        {
            var query = @"SELECT
                        li.listingId,
                        li.price,
                        li.creationTimeStamp,
                        li.itemInstanceId_fk AS ItemInstanceId,
                        li.sellerAccountId_fk AS SellerAccountId,

                        af.accountId,
                        af.userName,
                        af.surName,
                        af.email,
                        af.phoneNo,

                        ii.itemInstanceId,
                        ii.itemDefinitionId_fk,
                        ii.accountId_fk AS ItemInstanceAccountId,

                        id.itemDefinitionId,
                        id.itemName,
                        id.itemDescription,
                        id.gameId_fk,

                        g.gameId,
                        g.gameTitle

                        FROM Listing li

                        LEFT JOIN Account af
                        ON af.accountId = li.sellerAccountId_fk

                        LEFT JOIN ItemInstance ii
                        ON ii.itemInstanceId = li.itemInstanceId_fk

                        LEFT JOIN ItemDefinition id
                        ON id.itemDefinitionId = ii.itemDefinitionId_fk

                        LEFT JOIN Game g
                        ON g.gameId = id.gameId_fk

                        WHERE li.statusId_fk = 1; ";

            IEnumerable<Listing> listings = connection.Query<Listing, Account, ItemInstance, ItemDefinition, Game, Listing>(
                query,
                (listing, account, itemInstance, itemDef, game) =>
                {
                    itemDef.Game = game;
                    itemInstance.ItemDefinition = itemDef;

                    listing.SellerAccount = account;
                    listing.ItemInstance = itemInstance;


                    return listing;
                },
                    splitOn: "accountId,itemInstanceId,itemDefinitionId,gameId"
                );

            return listings;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while trying to get all listings. Error was: '{ex.Message}'", ex);
        }
    }


    //Lav om til at returnere en id istedet og opdater interface og ændre "Create til Insert"
    public int ValidateAndInsertListing(Listing listing)
    {
        using var connection = CreateConnection();
        try
        {
            var queryActiveStatusForItem = @"SELECT COUNT(*)
                                            FROM Listing
                                            WHERE itemInstanceId_fk = @itemInstanceId
                                            AND statusId_fk = 1";

            int rowCount = connection.ExecuteScalar<int>(queryActiveStatusForItem, new { itemInstanceId = listing.ItemInstanceId });

            if (rowCount > 0)
            {
                throw new Exception($"Cant create listing with ItemInstance with id {listing.ItemInstanceId} - Already Active");
            }

            var queryInsertListing = @"INSERT INTO Listing
            (price, creationTimeStamp, statusId_fk, itemInstanceId_fk, sellerAccountId_fk)
            OUTPUT INSERTED.listingId
            VALUES
            (@Price, @CreationTimeStamp, @StatusId, @ItemInstanceId, @SellerAccountId)";

            int listingId = connection.ExecuteScalar<int>(queryInsertListing, new
            {
                listing.Price,
                listing.CreationTimeStamp,
                listing.StatusId,
                listing.ItemInstanceId,
                listing.SellerAccountId
            });
            return listingId;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while trying to create listing. Error was: '{ex.Message}'", ex);
        }
    }


    //Skal vi lave metoder i ItemInstance og Wallet DAO istedet for at gøre det hele her???
    public bool BuyListing(int buyerAccountId, int listingId)
    {
        //Opretter en forbindelse ud fra BaseDao
        using var connection = CreateConnection();

        //Åbner forbindelse
        connection.Open();

        //Starter Transaction
        using var transaction = connection.BeginTransaction();

        //UPDATE Listing
        //STATUS til 2 (Sold) og buyerAccountId til "buyerAccountId"
        //Hvor ListingId = listing.ListingId og STATUS = 1 (Active) og buyerAccoundId_fk = NULL
        //Rollback hvis rowsAffected = 0
        try
        {
            var queryUpdateListing = @"UPDATE Listing 
                        SET statusId_fk = 2, buyerAccountId_fk = @BuyerAccountId
                        WHERE listingId = @ListingId
                        AND statusId_fk = 1
                        AND buyerAccountId_fk IS NULL";

            int rowsAffectedListing = connection.Execute(queryUpdateListing, 
            new { BuyerAccountId = buyerAccountId, ListingId = listingId }, transaction);

            if (rowsAffectedListing == 0)
            {
                throw new Exception("Couldnt Update listing buyer and status");
            }

        //UPDATE ItemInstance
        //accountId_fk til buyerAccountId
        //Hvor ItemInstanceId = listing.ItemInstanceId
            var queryUpdateItemInstance = @"UPDATE ItemInstance 
                        SET accountId_fk = @AccountId
                        WHERE itemInstanceId = 
                        (SELECT itemInstanceId_fk FROM Listing WHERE listingId = @ListingId)";

            int rowsAffectedItemInstance = connection.Execute(queryUpdateItemInstance,
            new { AccountId = buyerAccountId, ListingId = listingId }, transaction);

            if (rowsAffectedItemInstance == 0)
            {
                transaction.Rollback();
                throw new Exception("Couldnt transfer iteminstance");
            }

        //UPDATE Wallet
        //Til at balance trækker pris fra listing fra
        //Hvor accountId_fk = buyeraccountid
        //Og hvor balance er højere en listings pris
            var queryUpdateWalletBuyer = @"UPDATE Wallet
                        SET balance = balance - 
                        (SELECT price FROM Listing WHERE listingId = @ListingId)
                        WHERE accountId_fk = @BuyerAccountId
                        AND balance >= 
                        (SELECT price FROM Listing WHERE listingId = @ListingId)";

            int rowsAffectedWalletBuyer = connection.Execute(queryUpdateWalletBuyer,
            new { BuyerAccountId = buyerAccountId, ListingId = listingId }, transaction);

            if (rowsAffectedWalletBuyer == 0)
            {
                transaction.Rollback();
                throw new Exception("Couldnt withdraw money from buyer");
            }

            var queryUpdateWalletSeller = @"UPDATE Wallet
                        SET balance = balance + 
                        (SELECT price FROM Listing WHERE listingId = @ListingId)
                        WHERE accountId_fk =
                        (SELECT sellerAccountId_fk FROM Listing WHERE listingId = @ListingId)
                        ";

            int rowsAffectedWalletSeller = connection.Execute(queryUpdateWalletSeller,
            new { ListingId = listingId }, transaction);

            if (rowsAffectedWalletSeller == 0)
            {
                transaction.Rollback();
                throw new Exception("Couldnt deposit money to seller");
            }

            //Commit transaction
            transaction.Commit();
        //Returner true
            return true;
        }
        catch (Exception ex)
        {
            transaction.Rollback(); //fix exception try/catch
            throw new Exception($"Error while trying to buy listing. Error was: '{ex.Message}'", ex);
        }
    }

    // Henter listen af items, hvor db har filteret dem til kun dem som skal bruges til marketplace filteret
    public IEnumerable<Listing> GetFilteredListings(string? game, int? minPrice, int? maxPrice, string? sort, string? search)
    {
        using var connection = CreateConnection();

        var sql = @"
        SELECT
            li.listingId,
            li.price,
            li.creationTimeStamp,
            li.itemInstanceId_fk AS ItemInstanceId,
            li.sellerAccountId_fk AS SellerAccountId,

            af.accountId,
            af.userName,
            af.surName,
            af.email,
            af.phoneNo,

            ii.itemInstanceId,
            ii.itemDefinitionId_fk,
            ii.accountId_fk AS ItemInstanceAccountId,

            id.itemDefinitionId,
            id.itemName,
            id.itemDescription,
            id.gameId_fk,

            g.gameId,
            g.gameTitle

        FROM Listing li

        LEFT JOIN Account af ON af.accountId = li.sellerAccountId_fk
        LEFT JOIN ItemInstance ii ON ii.itemInstanceId = li.itemInstanceId_fk
        LEFT JOIN ItemDefinition id ON id.itemDefinitionId = ii.itemDefinitionId_fk
        LEFT JOIN Game g ON g.gameId = id.gameId_fk

        WHERE li.statusId_fk = 1
    ";

        var parameters = new DynamicParameters();

        if (!string.IsNullOrEmpty(search))
        {
            sql += " AND id.itemName LIKE @search";
            parameters.Add("@search", $"%{search}%");
        }

        if (!string.IsNullOrEmpty(game))
        {
            sql += " AND g.gameTitle = @game";
            parameters.Add("@game", game);
        }

        if (minPrice.HasValue)
        {
            sql += " AND li.price >= @minPrice";
            parameters.Add("@minPrice", minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            sql += " AND li.price <= @maxPrice";
            parameters.Add("@maxPrice", maxPrice.Value);
        }

        if (sort == "low")
        {
            sql += " ORDER BY li.price ASC";
        }
        else if (sort == "high")
        {
            sql += " ORDER BY li.price DESC";
        }

        var listings = connection.Query<Listing, Account, ItemInstance, ItemDefinition, Game, Listing>(
            sql,
            (listing, account, itemInstance, itemDef, gameObj) =>
            {
                itemDef.Game = gameObj;
                itemInstance.ItemDefinition = itemDef;

                listing.SellerAccount = account;
                listing.ItemInstance = itemInstance;

                return listing;
            },
            parameters,
            splitOn: "accountId,itemInstanceId,itemDefinitionId,gameId"
        );

        return listings.AsList();
    }

    public Listing GetActiveListingById(int listingId)
    {
        using var connection = CreateConnection();

        try
        {
            var query = @"SELECT
                        li.listingId,
                        li.price,
                        li.creationTimeStamp,
                        li.itemInstanceId_fk AS ItemInstanceId,
                        li.sellerAccountId_fk AS SellerAccountId,

                        af.accountId,
                        af.userName,
                        af.surName,
                        af.email,
                        af.phoneNo,

                        ii.itemInstanceId,
                        ii.itemDefinitionId_fk,
                        ii.accountId_fk AS ItemInstanceAccountId,

                        id.itemDefinitionId,
                        id.itemName,
                        id.itemDescription,
                        id.gameId_fk,

                        g.gameId,
                        g.gameTitle

                        FROM Listing li

                        LEFT JOIN Account af
                        ON af.accountId = li.sellerAccountId_fk

                        LEFT JOIN ItemInstance ii
                        ON ii.itemInstanceId = li.itemInstanceId_fk

                        LEFT JOIN ItemDefinition id
                        ON id.itemDefinitionId = ii.itemDefinitionId_fk

                        LEFT JOIN Game g
                        ON g.gameId = id.gameId_fk

                        WHERE li.listingId = @ListingId
                        AND li.statusId_fk = 1";

            Listing? listing = connection.Query<Listing, Account, ItemInstance, ItemDefinition, Game, Listing>(
                        query,
                        (list, account, itemInstance, itemDef, game) =>
                        {
                            itemDef.Game = game;
                            itemInstance.ItemDefinition = itemDef;
                            list.SellerAccount = account;
                            list.ItemInstance = itemInstance;
                            return list;
                        },
                        new { listingId },
                        splitOn: "accountId,itemInstanceId,itemDefinitionId,gameId"
                    ).SingleOrDefault();

            return listing;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while trying to get listing. Error was: '{ex.Message}'", ex);
        }
    }
    public bool IsItemInstanceListed(int itemInstanceId)
    {
        using var connection = CreateConnection();

        var query = @"SELECT COUNT(*)
                  FROM Listing
                  WHERE itemInstanceId_fk = @ItemInstanceId
                  AND statusId_fk = 1";

        int count = connection.ExecuteScalar<int>(query, new
        {
            ItemInstanceId = itemInstanceId
        });

        return count > 0;
    }

}
