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

        //DAO metode til at indsætte et Game
        public int InsertGame(Game game)
        {
            try
            {
                var query = @"INSERT INTO Game 
                              (gameTitle, gameStudio)
                              OUTPUT INSERTED.gameId
                              VALUES (@GameTitle, @GameStudio)";

                using var connection = CreateConnection();
                return connection.QuerySingle<int>(query, game);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error inserting game with title='{game.GameTitle}'. Error: '{ex.Message}'", ex);
            }
        }

        //DAO metode til at slette et Game ud fra Id
        public bool DeleteGame(int id)
        {
            try
            {
                var query = "DELETE FROM Game WHERE gameId = @Id";

                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, new { Id = id });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error deleting game with id='{id}'. Error: '{ex.Message}'", ex);
            }
        }
    }
}