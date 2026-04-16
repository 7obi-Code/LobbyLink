using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ItemPropertyDao : BaseDao, IFItemPropertyDao
    {
        public ItemPropertyDao(string connectionString) : base(connectionString) { }

        public bool DeleteItemProperty(int id)
        {
            try
            {
                var query = "DELETE FROM ItemProperty WHERE Id=@Id";
                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, new { id });
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error while trying to delete ItemProperty with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }

        public IEnumerable<ItemProperty> GetAllItemProperties()
        {
            try
            {
                var query = "SELECT * FROM ItemProperty";
                using var connection = CreateConnection();
                return connection.Query<ItemProperty>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get all Item Properties. Error was: '{ex.Message}'", ex);
            }
        }

        public ItemProperty? GetItemPropertyById(int id)
        {
            try
            {
                var query = "SELECT * FROM ItemProperty WHERE Id=@Id";
                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<ItemProperty>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get ItemProperty with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }

        public int InsertItemProperty(ItemProperty itemProperty)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemProperty(ItemProperty itemProperty)
        {
            throw new NotImplementedException();
        }
    }
}
