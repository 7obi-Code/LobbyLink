using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ListingDao : BaseDao, IFListingDao
    {
        public ListingDao(string connectionString) : base(connectionString) { }

        public IEnumerable<Listing> GetAllActiveListings()
        {
            try
            {
                var query = "SELECT * FROM Listing WHERE Status=@Active";
                using var connectingString = CreateConnection();
                return connectingString.Query<Listing>(query);
            } catch (Exception ex) {
                throw new Exception($"Error while trying to get all listings. Error was: '{ex.Message}'", ex);
            }
        }
    }
}
