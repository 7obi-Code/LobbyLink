using LobbyLink.DataAccess.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using LobbyLink.DataAccess.Model;

namespace LobbyLink.DataAccess.SQLClient
{
    public class GameDao : BaseDao, IFGameDao
    {
        public GameDao(string connectionString) : base(connectionString) { }

        public IEnumerable<Game> GetAllGames(int id)
        {
            try
            {
                var query = "SELECT * FROM Game";
                using var connection = CreateConnection();
                return connection.Query<Game>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get all Games. Error was: '{ex.Message}'", ex);
            }
        }

        public Game? GetGameByID(int id)
        {
            try
            {
                var query = "SELECT * FROM Game WHERE id=@id";
                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<Game>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get a Game by id. Error was: '{ex.Message}'", ex);
            }
        }
    }
}
