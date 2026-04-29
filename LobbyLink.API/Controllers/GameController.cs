using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameDao _gameDao;

    public GameController()
    {
        _gameDao = new GameDao("Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V252_10666018;User ID=DMA-CSD-V252_10666018;Password=Password1!;Trust Server Certificate=True;");
    }

    [HttpGet]
    public ActionResult<IEnumerable<Game>> Get()
    {
        return Ok(_gameDao.GetAllGames());
    }
}