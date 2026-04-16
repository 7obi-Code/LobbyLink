using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ItemInstancePropertyDao : BaseDao, IFItemInstancePropertyDao

    {
        public ItemInstancePropertyDao(string connectionString) : base(connectionString) { }
        public IEnumerable<ItemInstanceProperty> GetAllItemInstanceProperties()
        {
            try
            {
                var query = "SELECT * FROM ItemInstanceProperties";
                using var connection = CreateConnection();
                return connection.Query<ItemInstanceProperty>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get all ItemInstanceProperties. Error was: '{ex.Message}'", ex);
            }
        }

        public ItemInstanceProperty? GetItemInstanceProperty(int id)
        {
            try
            {
                var query = "SELECT * FROM ItemInstanceProperties WHERE Id=@Id";
                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<ItemInstanceProperty>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get ItemInstanceProperties with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }
    }
}
