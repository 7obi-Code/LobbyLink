using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemInstancesController : ControllerBase
    {
        ItemInstanceDao _itemInstanceDao;

        //API opbygger controller med IConfiguration interfacet, som tager ConnectionString fra appsettings.json
        public ItemInstancesController(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Couldnt find connection string");
            }

            _itemInstanceDao = new ItemInstanceDao(connectionString);
        }

        //Endpoint til at få alle ItemInstances
        [HttpGet]
        public ActionResult<IEnumerable<ItemInstance>> Get()
        {
            try
            {
                return Ok(_itemInstanceDao.GetAllItemInstances());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving all item instances", error = ex.Message });
            }
        }

        //Endpoint til at finde alle ItemInstances ud fra et bruger Id
        [HttpGet("account/{accountId}")]
        public ActionResult<IEnumerable<ItemInstance>> GetByAccountId(int accountId)
        {
            try
            {
                return Ok(_itemInstanceDao.GetAllItemInstancesByAccountId(accountId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving item instances for accountId: {accountId}", error = ex.Message });
            }
        }

        //Endpoint til at finde en ItemInstance ud fra et Id
        [HttpGet("{itemInstanceId}")]
        public ActionResult<ItemInstance> GetById(int itemInstanceId)
        {
            try
            {
                var item = _itemInstanceDao.GetItemInstanceById(itemInstanceId);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Error retrieving item instance {itemInstanceId}",
                    error = ex.Message
                });
            }
        }

        //Endpoint til at oprette et nyt ItemInstance
        [HttpPost]
        public ActionResult<int> Post([FromBody] ItemInstance itemInstance)
        {
            try
            {
                if (itemInstance == null)
                    return BadRequest("ItemInstance was null.");

                if (itemInstance.ItemDefinitionId <= 0)
                    return BadRequest("ItemDefinitionId must be greater than 0.");

                if (itemInstance.AccountId <= 0)
                    return BadRequest("AccountId must be greater than 0.");

                int newId = _itemInstanceDao.CreateItemInstance(itemInstance);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error creating item instance",
                    error = ex.Message
                });
            }
        }
    }
}
