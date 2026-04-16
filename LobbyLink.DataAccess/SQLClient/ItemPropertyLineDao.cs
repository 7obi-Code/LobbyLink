using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ItemPropertyLineDao : BaseDao, IFItemPropertyLineDao
    {

        public ItemPropertyLineDao(string connectionString) : base(connectionString) { }

        public bool DeleteItemPropertyLine(int id)
        {
            try
            {
                var query = "DELETE FROM ItemPropertyLine WHERE Id=@Id";
                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, new { id });
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error while trying to delete ItemPropertyLine with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }

        public IEnumerable<ItemPropertyLine> GetAllItemPropertyLines()
        {
            try
            {
                var query = "SELECT * FROM ItemPropertyLine";
                using var connection = CreateConnection();
                return connection.Query<ItemPropertyLine>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get all ItemPropertyLines. Error was: '{ex.Message}'", ex);
            }
        }

        public ItemPropertyLine? GetItemPropertyLineById(int id)
        {
            try
            {
                var query = "SELECT * FROM ItemPropertyLine WHERE Id=@Id";
                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<ItemPropertyLine>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get ItemPropertyLine with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }

        public IEnumerable<ItemPropertyLine> GetLinesByItemDefinitionId(int itemDefinitionId)
        {
            try
            {
                var query = "SELECT * FROM ItemPropertyLine WHERE ItemDefinitionId = @itemDefinitionId";

                using var connection = CreateConnection();
                return connection.Query<ItemPropertyLine>(query, new { itemDefinitionId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get ItemPropertyLines for ItemDefinitionId='{itemDefinitionId}'. Error was: '{ex.Message}'", ex);
            }
        }

        public IEnumerable<ItemPropertyLine> GetLinesByPropertyId(int propertyId)
        {
            try
            {
                var query = "SELECT * FROM ItemPropertyLine WHERE PropertyId = @propertyId";

                using var connection = CreateConnection();
                return connection.Query<ItemPropertyLine>(query, new { propertyId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get ItemPropertyLines for PropertyId='{propertyId}'. Error was: '{ex.Message}'", ex);
            }
        }

        public int InsertItemPropertyLine(ItemPropertyLine itemPropertyLine)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemPropertyLine(ItemPropertyLine itemPropertyLine)
        {
            throw new NotImplementedException();
        }
    }
}
