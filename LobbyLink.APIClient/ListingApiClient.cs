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

            BuyListingRequest rq = new BuyListingRequest
            {
                BuyerAccountId = buyerAccountId,
                ListingId = listingId
            };

            request.AddJsonBody(rq);

            var response = _client.Execute<bool>(request);

            if (response.IsSuccessful)
            {
                return true;
            }
            return false;
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
        public bool IsItemInstanceListed(int itemInstanceId)
        {
            var request = new RestRequest($"active/iteminstance/{itemInstanceId}");
            var response = _client.Execute<bool>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            Console.WriteLine(response.Content);
            return false;
        }
        public IEnumerable<Listing> GetFilteredListings(string? game, int? minPrice, int? maxPrice, string? sort, string? search)
        {
            var queryParams = $"?game={game}&minPrice={minPrice}&maxPrice={maxPrice}&sort={sort}&search={search}";
            var request = new RestRequest(queryParams, Method.Get);

            var response = _client.Execute<List<Listing>>(request);

            return response.Data ?? new List<Listing>();
        }
    }
}