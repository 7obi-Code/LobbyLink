using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFListingDao
    {
        IEnumerable<Listing> GetAllActiveListings();

        Listing GetLatestListingByItemInstanceId();
        //Oprettelse af en listing. 
        int InsertListing(Listing listing);

    }
}
