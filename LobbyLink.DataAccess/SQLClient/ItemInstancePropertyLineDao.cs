using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ItemInstancePropertyLineDao : BaseDao, IFItemInstancePropertyLineDao
    {
        public ItemInstancePropertyLineDao(string connectionString) : base(connectionString) { }

        public bool DeleteItemInstancePropertyLine(int id)
        {
            throw new NotImplementedException();
        }
        //hej
        public IEnumerable<ItemInstancePropertyLine> GetAllItemInstancePropertyLines()
        {
            try
            {
                var query = "SELECT * FROM ItemInstancePropertyLine";
                using var connection = CreateConnection();
                return connection.Query<ItemInstancePropertyLine>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get all ItemInstancePropertyLine. Error was: '{ex.Message}'", ex);
            }
        }

        public ItemInstancePropertyLine? GetItemInstancePropertyLineById(int id)
        {
            try
            {
                var query = "SELECT * FROM ItemInstancePropertyLine WHERE Id=@Id";
                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<ItemInstancePropertyLine>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get ItemInstancePropertyLine with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }

        public int InsertItemInstancePropertyLine(ItemInstancePropertyLine itemInstancePropertyLine)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemInstancePropertyLine(ItemInstancePropertyLine itemInstancePropertyLine)
        {
            throw new NotImplementedException();
        }
    }
}
