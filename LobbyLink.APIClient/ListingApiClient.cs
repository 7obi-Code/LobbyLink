using LobbyLink.API.DTOs;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.APIClient
{
    // Denne klasse står for al kommunikation med vores Listings API
    // Den bruger RestSharp til at sende HTTP requests og modtage svar
    public class ListingApiClient(string restUrl) : IFListingDao
    {
        // RestClient er RestSharps HTTP klient, sat op med vores API's basis URL
        RestClient _client = new RestClient(restUrl);

        public IEnumerable<Listing> GetAllActiveListings()
        {
            // Bygger et GET request til "api/v1/listings/active"
            var request = new RestRequest("active");

            // Sender requestet og forventer en liste af Listings tilbage som JSON
            var response = _client.Execute<List<Listing>>(request);

            // Hvis noget gik galt, log fejlen og returner en tom liste
            if (!response.IsSuccessful || response.Data == null)
            {
                Console.WriteLine(response.Content);
                return new List<Listing>();
            }

            return response.Data;
        }

        public int ValidateAndInsertListing(Listing listing)
        {
            // Bygger et POST request til "api/v1/listings"
            var request = new RestRequest("", Method.Post);

            // Vedhæfter listing objektet som JSON i request body
            request.AddJsonBody(listing);

            // Sender requestet og forventer det nye listings ID tilbage
            var response = _client.Execute<int>(request);

            // Hvis det lykkedes, returner det nye ID
            if (response.IsSuccessful && response.Data != 0)
            {
                return response.Data;
            }

            // Hvis det fejlede, smid en exception med detaljer om hvad der gik galt
            throw new Exception(
            $"Failed to insert listing. " +
            $"Status code: {response.StatusCode}, " +
            $"Error: {response.ErrorMessage}, " +
            $"Content: {response.Content}");
        }

        public bool BuyListing(int buyerAccountId, int listingId)
        {
            // Bygger et PUT request til "api/v1/listings"
            var request = new RestRequest("", Method.Put);

            // Opretter request body objektet med køber og listing info
            BuyListingRequest rq = new BuyListingRequest
            {
                BuyerAccountId = buyerAccountId,
                ListingId = listingId
            };

            // Vedhæfter det som JSON i request body
            request.AddJsonBody(rq);

            var response = _client.Execute<bool>(request);

            if (response.IsSuccessful)
            {
                return true;
            }
            return false;

            // Smider en exception med fejlbeskeden fra API'et -> Lavet så fejlbesked kan kastes korrekt i marketplace buy
            throw new Exception(
                $"Købet fejlede. " +
                $"Status: {response.StatusCode}, " +
                $"Fejl: {response.Content}");
        }

        public Listing? GetActiveListingById(int listingId)
        {
            // Bygger et GET request til "api/v1/listings/active/{listingId}"
            var request = new RestRequest($"active/{listingId}");

            // Sender requestet og forventer et enkelt Listing objekt tilbage
            var response = _client.Execute<Listing>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            // Returner null hvis listing ikke blev fundet
            return null;
        }

        public bool IsItemInstanceListed(int itemInstanceId)
        {
            // Bygger et GET request til "api/v1/listings/active/iteminstance/{itemInstanceId}"
            var request = new RestRequest($"active/iteminstance/{itemInstanceId}");

            // Sender requestet og forventer en bool tilbage (true = på markedet, false = ikke på markedet)
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
            // Bygger et GET request til "api/v1/listings/filtered"
            var request = new RestRequest("filtered", Method.Get);

            // Tilføjer hvert filter som en query parameter i URL'en
            // ?? "" betyder "brug tom streng hvis værdien er null"
            // så URL'en bliver f.eks. filtered?game=CS2&minPrice=10&maxPrice=100&sort=low&search=knife
            request.AddQueryParameter("game", game ?? "");
            request.AddQueryParameter("minPrice", minPrice?.ToString() ?? "");
            request.AddQueryParameter("maxPrice", maxPrice?.ToString() ?? "");
            request.AddQueryParameter("sort", sort ?? "");
            request.AddQueryParameter("search", search ?? "");

            // Sender requestet og forventer en filtreret liste af Listings tilbage
            var response = _client.Execute<List<Listing>>(request);

            // Hvis noget gik galt, log fejlen og returner en tom liste
            if (!response.IsSuccessful || response.Data == null)
            {
                Console.WriteLine(response.Content);
                return new List<Listing>();
            }

            return response.Data;
        }
    }
}