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

            try {   var query =
                @"SELECT 
                    li.listingId,
                    li.price,
                    li.creationTimeStamp,
                    li.status,
                    li.itemInstanceId_fk,
                    li.accountId_fk,

                    af.accountId,
                    af.userName,
                    af.surName,
                    af.email,
                    af.phoneno,

                    ii.itemInstanceId,
                    ii.itemDefinitionId_fk,
                    ii.accountId_fk AS ItemInstanceAccountId

                FROM Listing li
                    INNER JOIN Account af 
                        ON af.accountId = li.accountId_fk

                    INNER JOIN ItemInstance ii 
                        ON ii.itemInstanceId = li.itemInstanceId_fk

                WHERE li.status = @Active";

                return connection.Query<Listing, Account, ItemInstance, Listing>(
                        query,
                        (listing, account, itemInstance) =>
                        {
                            listing.Account = account;
                            listing.ItemInstance = itemInstance;
                            return listing;
                        },
                        new { Active = "ACTIVE" },
                        splitOn: "accountId,itemInstanceId"
                );

            } catch (Exception ex) {
                throw new Exception($"Error while trying to get all listings. Error was: '{ex.Message}'", ex);
            }

        }
    }
}
