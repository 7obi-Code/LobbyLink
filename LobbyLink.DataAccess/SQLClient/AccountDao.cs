using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;

namespace LobbyLink.DataAccess.SqlClient
{
    public class AccountDao : BaseDao, IFAccountDao
    {
        public AccountDao(string connectionString) : base(connectionString) { }

        public bool DeleteAccount(int id)
        {
            try
            {
                var query = "DELETE FROM Account WHERE accountId = @Id";

                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, new { Id = id });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error deleting account with id='{id}'. Error: '{ex.Message}'", ex);
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            try
            {
                var query = @"SELECT 
                                accountId AS AccountId,
                                userName  AS UserName,
                                firstName AS FirstName,
                                surName   AS SurName,
                                email     AS Email,
                                phoneNo   AS PhoneNo,
                                level     AS Level,
                                type      AS Type
                              FROM Account";

                using var connection = CreateConnection();
                return connection.Query<Account>(query);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error getting all accounts. Error: '{ex.Message}'", ex);
            }
        }

        public Account? GetAccountById(int id)
        {
            try
            {
                var query = @"SELECT 
                                accountId AS AccountId,
                                userName  AS UserName,
                                firstName AS FirstName,
                                surName   AS SurName,
                                email     AS Email,
                                phoneNo   AS PhoneNo,
                                level     AS Level,
                                type      AS Type
                              FROM Account
                              WHERE accountId = @Id";

                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<Account>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error getting account with id='{id}'. Error: '{ex.Message}'", ex);
            }
        }

        public int InsertAccount(Account account)
        {
            try
            {
                var query = @"INSERT INTO Account 
                              (userName, firstName, surName, email, phoneNo, level, type)
                              OUTPUT INSERTED.accountId
                              VALUES (@UserName, @FirstName, @SurName, @Email, @PhoneNo, @Level, @Type)";

                using var connection = CreateConnection();
                return connection.QuerySingle<int>(query, account);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error inserting account with email='{account.Email}'. Error: '{ex.Message}'", ex);
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                var query = @"UPDATE Account
                              SET userName  = @UserName,
                                  firstName = @FirstName,
                                  surName   = @SurName,
                                  email     = @Email,
                                  phoneNo   = @PhoneNo,
                                  level     = @Level,
                                  type      = @Type
                              WHERE accountId = @AccountId";

                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, account);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error updating account with id='{account.AccountId}'. Error: '{ex.Message}'", ex);
            }
        }
    }
}