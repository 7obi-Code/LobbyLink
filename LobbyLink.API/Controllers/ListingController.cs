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

            _listingDao = new BusinessLogic(new ListingDao(
                "Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V252_10666018;User ID=DMA-CSD-V252_10666018;Password=Password1!;Trust Server Certificate=True;"));
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
    }
}