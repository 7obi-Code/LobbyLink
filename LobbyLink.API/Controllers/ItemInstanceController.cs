using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemInstanceController : ControllerBase
    {
        ItemInstanceDao _itemInstanceDao;

        public ItemInstanceController() => _itemInstanceDao = new ItemInstanceDao("Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V252_10666018;User ID=DMA-CSD-V252_10666018;Password=Password1!;Trust Server Certificate=True;");

        [HttpGet]
        public ActionResult<IEnumerable<ItemInstance>> Get()
        { 
            try
            {
                return Ok(_itemInstanceDao.GetAllItemInstances());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving item instances", error = ex.Message });
            }
        }
    }
}
