using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;

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
                        li.accountId_fk AS AccountId,

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
                        ON af.accountId = li.accountId_fk

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
            var queryLatestStatus = @"SELECT TOP 1 statusId_fk
                            FROM Listing
                            WHERE itemInstanceId_fk = @itemInstanceId
                            ORDER BY creationTimeStamp DESC";

            int? latestStatusId = connection.QueryFirstOrDefault<int>(queryLatestStatus, new { itemInstanceId = listing.ItemInstanceId });

            ListingStatus latestStatus = (ListingStatus)latestStatusId;

            if (latestStatus == ListingStatus.ACTIVE)
            {
                throw new Exception($"Cant create listing with ItemInstance with id {listing.ItemInstanceId} - Already Active");
            }

            var queryInsertListing = @"INSERT INTO Listing
            (price, creationTimeStamp, statusId,fk, itemInstanceId_fk, accountId_fk)
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
}
