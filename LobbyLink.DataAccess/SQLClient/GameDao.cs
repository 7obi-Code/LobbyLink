using LobbyLink.DataAccess.Interfaces;
using Dapper;
using LobbyLink.DataAccess.Model;

namespace LobbyLink.DataAccess.SQLClient
{
    public class GameDao : BaseDao, IFGameDao
    {
        public GameDao(string connectionString) : base(connectionString) { }

        //DAO metode til at get alle Games
        public IEnumerable<Game> GetAllGames()
        {
            try
            {
                var query = @"SELECT 
                              gameId     AS GameId,
                              gameTitle  AS GameTitle
                              FROM Game";

                using var connection = CreateConnection();
                return connection.Query<Game>(query);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving all games. Error: '{ex.Message}'", ex);
            }
        }
    }
}