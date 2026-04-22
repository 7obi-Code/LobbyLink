using LobbyLink.API.Models;
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

        // GET: api/v1/listing/has-active/5
        [HttpGet("has-active/{itemInstanceId}")]
        public ActionResult<bool> HasActiveListingForItemInstance(int itemInstanceId)
        {
            try
            {
                bool result = _listingDao.HasActiveListingForItemInstance(itemInstanceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error checking active listing for item instance",
                    error = ex.Message
                });
            }
        }
        
        // POST: api/v1/listing
        [HttpPost]
        public ActionResult<int> InsertListing([FromBody] Listing listing)
        {
            try
            {
                if (_listingDao.HasActiveListingForItemInstance(listing.ItemInstanceId))
                {
                    return BadRequest("Item is already listed.");
                }

                Listing listing = new Listing
                {
                    Price = request.Price,
                    Status = "ACTIVE",
                    CreationTimeStamp = DateTime.Now,
                    ItemInstanceId = request.ItemInstanceId,
                    AccountId = request.AccountId,
                    ItemInstance = new ItemInstance { ItemInstanceId = request.ItemInstanceId },
                    Account = new Account { AccountId = request.AccountId }
                };

                Listing createdListing = _listingDao.CreateListing(listing);
                return Ok(createdListing);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}