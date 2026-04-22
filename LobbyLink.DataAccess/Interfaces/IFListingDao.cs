using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFListingDao
    {
        IEnumerable<Listing> GetAllActiveListings();

        //Oprettelse af en listing. 
        int ValidateAndInsertListing(Listing listing);

    }
}
