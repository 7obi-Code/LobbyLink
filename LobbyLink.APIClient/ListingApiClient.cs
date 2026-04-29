using LobbyLink.API.DTOs;
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
                Console.WriteLine(response.Content);
                return new List<Listing>();
            }

            return response.Data;
        }

        public int ValidateAndInsertListing(Listing listing)
        {
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(listing);
            var response = _client.Execute<int>(request);

            if (response.IsSuccessful && response.Data != 0)
            {
                return response.Data;
            }
            throw new Exception(
            $"Failed to insert listing. " +
            $"Status code: {response.StatusCode}, " +
            $"Error: {response.ErrorMessage}, " +
            $"Content: {response.Content}");
        }
        public bool BuyListing(int buyerAccountId, int listingId)
        {
            var request = new RestRequest("", Method.Put);
            request.AddJsonBody(new BuyListingRequest
            {
                BuyerAccountId = buyerAccountId,
                ListingId = listingId
            });

            var response = _client.Execute<bool>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            throw new Exception("Failed to buy listing");
        }

        public Listing? GetActiveListingById(int listingId)
        {
            var request = new RestRequest($"active/{listingId}");
            var response = _client.Execute<Listing>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            return null;
        }
    }
}