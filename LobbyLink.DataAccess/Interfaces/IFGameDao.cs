using LobbyLink.DataAccess.Model;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFGameDao
    {
        Game? GetGameById(int id);
        IEnumerable<Game> GetAllGames();
    }
}