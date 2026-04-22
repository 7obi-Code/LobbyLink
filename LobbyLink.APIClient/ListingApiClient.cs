using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.APIClient
{
    public class ListingApiClient(string restUrl) : IFListingDao
    {
        RestClient _client = new RestClient(restUrl);

        public IEnumerable<Listing> GetAllActiveListings()
        {
            var request = new RestRequest("active");
            var response = _client.Execute<List<Listing>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                Console.WriteLine(response.Content); // 🔥 critical for debugging
                return new List<Listing>();
            }

            return response.Data;
        }
    }
}
