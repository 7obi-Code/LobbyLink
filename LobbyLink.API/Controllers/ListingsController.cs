using LobbyLink.API.DTOs;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly ListingDao _listingDao;

        //API opbygger controller med IConfiguration interfacet, som tager ConnectionString fra appsettings.json
        public ListingsController(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Couldnt find connection string");
            }

            _listingDao = new ListingDao(connectionString);
        }

        //Endpoint til at finde alle ItemInstances ud fra de specificerede filtre. Disse er dynamiske og kan bliver kombineret
        [HttpGet("filtered")]
        public ActionResult<IEnumerable<Listing>> GetFilteredListings(string? game, int? minPrice, int? maxPrice, string? sort, string? search)
        {
            try
            {
                var listings = _listingDao.GetFilteredListings(game, minPrice, maxPrice, sort, search);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error retrieving filtered listings",
                    error = ex.Message
                });
            }
        }

        //Endpoint til at frem finde en listing ud fra et Id som har en status der er lig med "Active"
        [HttpGet("active/{listingId}")]
        public ActionResult<IEnumerable<Listing>> GetById(int listingId)
        {
            try
            {
                var listing = _listingDao.GetActiveListingById(listingId);
                return Ok(listing);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Error retrieving listing with id: {listingId}",
                    error = ex.Message
                });
            }
        }

        //Endpoint til at tjekke om en ItemInstance er koblet på en Listing med en status der er lig "Active"
        [HttpGet("active/iteminstance/{itemInstanceId}")]
        public ActionResult<bool> IsItemInstanceListed(int itemInstanceId)
        {
            try
            {
                bool isListed = _listingDao.IsItemInstanceListed(itemInstanceId);
                return Ok(isListed);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Error checking listing status for item instance {itemInstanceId}",
                    error = ex.Message
                });
            }
        }

        //Endpoint til at Oprette en ny listing
        [HttpPost]
        public ActionResult<int> Post([FromBody] Listing listing)
        {
            try
            {
                var newListingId = _listingDao.ValidateAndInsertListing(listing);

                return Ok(newListingId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error inserting item instance", error = ex.Message });
            }
        }

        //Endpoint til at købe et Item ud fra et DTO objekt af typen BuyListingRequest,
        //som kun indeholder et BuyerAccountId og ListingId
        [HttpPut]
        public ActionResult Put([FromBody] BuyListingRequest buyRequest)
        {
            try
            {
                if (buyRequest == null)
                {
                    return BadRequest(new { message = "No request was found" });
                }

                _listingDao.BuyListing(buyRequest.BuyerAccountId, buyRequest.ListingId);

                return Ok();
            }

            catch (ArgumentException aex)
            {
                return StatusCode(409, aex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}