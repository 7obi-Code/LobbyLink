using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace LobbyLink.DataAccess.SQLClient
{
    public class UserAccountDao : BaseDao, IFUserAccountDao
    {
       public UserAccountDao(string connectionString) : base(connectionString) {}
        
        public UserAccount? GetUserAccountById(int id)
        {
            try
            {
                var query = "SELECT * FROM USERACCOUNT WHERE Id=@Id";
                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<UserAccount>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to get UserAccount with the id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }


        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            try
            {
                var query = "SELECT * FROM USERACCOUNT";
                using var connection = CreateConnection();
                return connection.Query<UserAccount>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to get all UserAccounts. Error was: '{ex.Message}'", ex);
            }
        }
    }
}
