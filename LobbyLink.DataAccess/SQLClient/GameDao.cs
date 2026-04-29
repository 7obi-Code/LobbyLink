using LobbyLink.DataAccess.Interfaces;
using Dapper;
using LobbyLink.DataAccess.Model;

namespace LobbyLink.DataAccess.SQLClient
{
    public class GameDao : BaseDao, IFGameDao
    {
        public GameDao(string connectionString) : base(connectionString) { }

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

        public Game? GetGameById(int id)
        {
            try
            {
                var query = @"SELECT 
                                gameId     AS GameId,
                                gameTitle  AS GameTitle
                              FROM Game
                              WHERE gameId = @Id";

                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<Game>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving game with id='{id}'. Error: '{ex.Message}'", ex);
            }
        }
    }
}