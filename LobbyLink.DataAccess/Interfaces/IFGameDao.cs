using LobbyLink.DataAccess.Model;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFGameDao
    {
        IEnumerable<Game> GetAllGames();
    }
}