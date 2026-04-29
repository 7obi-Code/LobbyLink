using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SqlClient;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountDao _accountDao;

        public AccountController()
        {
            _accountDao = new AccountDao("Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V252_10666018;User ID=DMA-CSD-V252_10666018;Password=Password1!;Trust Server Certificate=True;");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            try
            {
                return Ok(_accountDao.GetAllAccounts());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving accounts", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetById(int id)
        {
            try
            {
                var account = _accountDao.GetAccountById(id);

                if (account == null)
                    return NotFound();

                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Error retrieving account {id}",
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Account account)
        {
            try
            {
                if (account == null)
                    return BadRequest("Account was null.");

                if (string.IsNullOrWhiteSpace(account.UserName))
                    return BadRequest("Username is required.");

                if (string.IsNullOrWhiteSpace(account.Email))
                    return BadRequest("Email is required.");

                int newId = _accountDao.InsertAccount(account);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error creating account",
                    error = ex.Message
                });
            }
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Account account)
        {
            try
            {
                if (account == null || account.AccountId <= 0)
                    return BadRequest("Invalid account.");

                bool updated = _accountDao.UpdateAccount(account);

                if (!updated)
                    return NotFound();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error updating account",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                bool deleted = _accountDao.DeleteAccount(id);

                if (!deleted)
                    return NotFound();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Error deleting account {id}",
                    error = ex.Message
                });
            }
        }
    }
}