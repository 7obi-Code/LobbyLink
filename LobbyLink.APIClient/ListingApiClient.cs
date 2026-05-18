using LobbyLink.API.DTOs;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;

namespace LobbyLink.APIClient
{
    public class ListingApiClient(string restUrl) : IFListingDao
    {
        RestClient _client = new RestClient(restUrl);

        //Request til at oprette en listing hvor der samtidigt bliver tjekket om det er muligt
        public int ValidateAndInsertListing(Listing listing)
        {
            var request = new RestRequest("", Method.Post);

            request.AddJsonBody(listing);

            var response = _client.Execute<int>(request);

            if (response.IsSuccessful && response.Data != 0)
            {
                return response.Data;
            }

            throw new Exception(response.ErrorMessage);
        }

        //Request til at købe en listing som opretter et BuyListingRequest opbjekt og sender videre som JSON body.
        public bool BuyListing(int buyerAccountId, int listingId)
        {
            var request = new RestRequest("", Method.Put);

            BuyListingRequest rq = new BuyListingRequest
            {
                BuyerAccountId = buyerAccountId,
                ListingId = listingId
            };

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

        //Request til at finde en aktiv listing ud fra et Id
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

        //Request til at tjkke om en ItemInstance er på en Listing med status til "Active"
        public bool IsItemInstanceListed(int itemInstanceId)
        {
            var request = new RestRequest($"active/iteminstance/{itemInstanceId}");

            var response = _client.Execute<bool>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            return false;
        }

        //Request til at finde Listings ud fra ønskede filtre
        public IEnumerable<Listing> GetFilteredListings(string? game = null, int? minPrice = null, int? maxPrice = null, string? sort = null, string? search = null)
        {
            var request = new RestRequest("filtered", Method.Get);

            // Tilføjer hvert filter som en query parameter i URL'en
            // så URLen bliver f.eks. filtered?game=CS2&minPrice=10&maxPrice=100&sort=low&search=knife
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