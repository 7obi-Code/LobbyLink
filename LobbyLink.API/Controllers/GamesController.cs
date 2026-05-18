using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
public class GamesController : ControllerBase
{
    private readonly GameDao _gameDao;

    //API opbygger controller med IConfiguration interfacet, som tager ConnectionString fra appsettings.json
    public GamesController(IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Couldnt find connection string");
        }

        _gameDao = new GameDao(connectionString);
    }

    //Endpoint til at get alle games
    [HttpGet]
    public ActionResult<IEnumerable<Game>> Get()
    {
        return Ok(_gameDao.GetAllGames());
    }
}