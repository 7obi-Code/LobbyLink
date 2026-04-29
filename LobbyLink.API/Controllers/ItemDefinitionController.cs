using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SqlClient;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemDefinitionController : ControllerBase
    {
        private readonly ItemDefinitionDao _ItemDefinitionDao;

        public ItemDefinitionController()
        {
            _ItemDefinitionDao = new ItemDefinitionDao("Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V252_10666018;User ID=DMA-CSD-V252_10666018;Password=Password1!;Trust Server Certificate=True;");
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDefinition>> Get()
        {
            try
            {
                return Ok(_ItemDefinitionDao.GetAllItemDefinitions());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error retrieving item definitions",
                    error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDefinition> GetById(int id)
        {
            try
            {
                var itemDefinition = _ItemDefinitionDao.GetItemDefinitionById(id);

                if (itemDefinition == null)
                    return NotFound();

                return Ok(itemDefinition);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Error retrieving itemDefinition {id}",
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] ItemDefinition itemDefinition)
        {
            try
            {
                if (itemDefinition == null)
                    return BadRequest("ItemDefinition was null.");

                if (string.IsNullOrWhiteSpace(itemDefinition.ItemName))
                    return BadRequest("ItemName is required.");

                if (itemDefinition.GameId <= 0)
                    return BadRequest("GameId must be valid.");

                int newId = _ItemDefinitionDao.InsertItemDefinition(itemDefinition);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error creating itemDefinition",
                    error = ex.Message
                });
            }
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] ItemDefinition itemDefinition)
        {
            try
            {
                if (itemDefinition == null || itemDefinition.ItemDefinitionId <= 0)
                    return BadRequest("Invalid itemDefinition.");

                bool updated = _ItemDefinitionDao.UpdateItemDefinition(itemDefinition);

                if (!updated)
                    return NotFound();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error updating itemDefinition",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                bool deleted = _ItemDefinitionDao.DeleteItemDefinition(id);

                if (!deleted)
                    return NotFound();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Error deleting itemDefinition {id}",
                    error = ex.Message
                });
            }
        }
    }
}