using Dapper;
using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFListingDao
    {
        int ValidateAndInsertListing(Listing listing);
        bool BuyListing(int buyerAccountId, int listingId);
        public IEnumerable<Listing> GetFilteredListings(string? game = null, int? minPrice = null, int? maxPrice = null, string? sort = null, string? search = null);
        Listing? GetActiveListingById(int listingId);
        bool IsItemInstanceListed(int itemInstanceId);
    }
}
