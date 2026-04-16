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

        public IEnumerable<ItemInstancePropertyLine> GetAllItemInstancePropertyLines()
        {
            try
            {
                var query = "SELECT * FROM BlogPost WHERE FK_UserAcc_Id=@AuthorId";
                using var connection = CreateConnection();
                return connection.Query<BlogPost>(query, new { AuthorId = authorId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get blog posts for author with id='{authorId}'. Error was: '{ex.Message}'", ex);
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
