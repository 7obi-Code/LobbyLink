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

        //Checker om Iteminstance er på en listing, for at view kan displaye et item forskelligt alt efter om det er sellable eller er sat til salg.
        bool IsItemInstanceListed(int itemInstanceId);


    }
}
