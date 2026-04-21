using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ListingDao : BaseDao, IFListingDao
    {
        public ListingDao(string connectionString) : base(connectionString) { }



        public IEnumerable<Listing> GetAllActiveListings()
        {
            using var connection = CreateConnection();

            try {   var query = @"SELECT 
                                li.listingId,
                                li.price,
                                li.creationTimeStamp,
                                li.status,
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

                            WHERE li.status = @Active";

                return connection.Query<Listing, Account, ItemInstance, ItemDefinition, Game, Listing>(
                    query,
                    (listing, account, itemInstance, itemDef, game) =>
                    {
                        itemDef.Game = game;
                        itemInstance.ItemDefinition = itemDef;

                        listing.Account = account;
                        listing.ItemInstance = itemInstance;

                        return listing;
                    },
                    new { Active = "ACTIVE" },
                    splitOn: "accountId,itemInstanceId,itemDefinitionId,gameId"
                );

            } catch (Exception ex) {
                throw new Exception($"Error while trying to get all listings. Error was: '{ex.Message}'", ex);
            }

        }
    }
}
