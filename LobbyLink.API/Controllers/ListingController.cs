using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly ListingDao _listingDao;

        public ListingController()
        {

            _listingDao = new ListingDao(
                "Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V252_10666018;User ID=DMA-CSD-V252_10666018;Password=Password1!;Trust Server Certificate=True;");
        }

        // GET: api/v1/listing/active
        [HttpGet("active")]
        public ActionResult<IEnumerable<Listing>> GetAllActiveListings()
        {
            try
            {
                var listings = _listingDao.GetAllActiveListings();
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error retrieving active listings",
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Listing listing)
        {
            try
            {
                if (listing.SellerAccountId <= 0 || listing.ItemInstanceId <= 0)
                {
                    return BadRequest(new { message = "A seller and a item instance are required" });
                }

                var newListingId = _listingDao.ValidateAndInsertListing(listing);
                return Ok(newListingId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error inserting item instance", error = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] Listing listingToUpdate)
        {
            try
            {
                if (listingToUpdate == null)
                {
                    return BadRequest(new { message = "No listing was found" });
                }

                if (listingToUpdate.BuyerAccountId <= 0)
                {
                    return BadRequest(new { message = "BuyerAccountId is required" });
                }

                bool result = _listingDao.BuyListing(listingToUpdate);
                if (result == false)
                {
                    return NotFound(new { message = $"Could not buy item" });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error buying listing with id {listingToUpdate.ListingId}", error = ex.Message });
            }
        }
    }
}