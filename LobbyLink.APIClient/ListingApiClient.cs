using LobbyLink.API.DTOs;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;

namespace LobbyLink.APIClient
{
    // Denne klasse står for al kommunikation med vores Listings API
    // Den bruger RestSharp til at sende HTTP requests og modtage svar
    public class ListingApiClient(string restUrl) : IFListingDao
    {
        // RestClient er RestSharps HTTP klient, sat op med vores API's basis URL
        RestClient _client = new RestClient(restUrl);

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
            throw new Exception(response.ErrorMessage);
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

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new ArgumentException(response.Content);
            }
            
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception(response.Content);
            }

            return false;
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

            return false;
        }

        public IEnumerable<Listing> GetFilteredListings(string? game = null, int? minPrice = null, int? maxPrice = null, string? sort = null, string? search = null)
        {
            // Bygger et GET request til "api/v1/listings/filtered"
            var request = new RestRequest("filtered", Method.Get);

            // Tilføjer hvert filter som en query parameter i URL'en
            // så URL'en bliver f.eks. filtered?game=CS2&minPrice=10&maxPrice=100&sort=low&search=knife
            if (!string.IsNullOrEmpty(game))
            {
                request.AddQueryParameter("game", game);
            }

            if (minPrice != null)
            {
            request.AddQueryParameter("minPrice", minPrice.ToString());
            }

            if (maxPrice != null)
            {
            request.AddQueryParameter("maxPrice", maxPrice.ToString());
            }

            if (!string.IsNullOrEmpty(sort))
            {
            request.AddQueryParameter("sort", sort);
            }

            if (!string.IsNullOrEmpty(search))
            {
            request.AddQueryParameter("search", search);
            }

            // Sender requestet og forventer en filtreret liste af Listings tilbage
            var response = _client.Execute<List<Listing>>(request);

            // Hvis noget gik galt, log fejlen og returner en tom liste
            if (!response.IsSuccessful || response.Data == null)
            {
                return new List<Listing>();
            }

            return response.Data;
        }
    }
}