using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFListingDao
    {
        IEnumerable<Listing> GetAllActiveListings();
        Listing? GetActiveListingById(int listingId);

        //Oprettelse af en listing. 
        int ValidateAndInsertListing(Listing listing);

        bool BuyListing(int buyerAccountId, int listingId);

    }
}
