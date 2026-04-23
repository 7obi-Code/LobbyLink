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
                throw new Exception($"Error while trying to delete account with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            try
            {
                var query = @"SELECT 
                                accountId   AS AccountId,
                                name        AS Name,
                                surname     AS Surname,
                                birthday    AS Birthday,
                                email       AS Email,
                                phoneno     AS PhoneNo,
                                type        AS Type
                              FROM Account";

                using var connection = CreateConnection();
                return connection.Query<Account>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get all accounts. Error was: '{ex.Message}'", ex);
            }
        }

        public Account? GetAccountById(int id)
        {
            try
            {
                var query = @"SELECT 
                                accountId   AS AccountId,
                                name        AS Name,
                                surname     AS Surname,
                                birthday    AS Birthday,
                                email       AS Email,
                                phoneno     AS PhoneNo,
                                type        AS Type
                              FROM Account
                              WHERE accountId = @Id";

                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<Account>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get account with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }

        public int InsertAccount(Account account)
        {
            try
            {
                var query = @"INSERT INTO Account (name, surname, birthday, email, phoneno, type)
                              OUTPUT INSERTED.accountId
                              VALUES (@Name, @Surname, @Birthday, @Email, @PhoneNo, @Type)";

                using var connection = CreateConnection();
                var newId = connection.QuerySingle<int>(query, account);
                return newId;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error while trying to insert account with email='{account.Email}'. Error was: '{ex.Message}'",
                    ex);
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                var query = @"UPDATE Account
                              SET name = @Name,
                                  surname = @Surname,
                                  birthday = @Birthday,
                                  email = @Email,
                                  phoneno = @PhoneNo,
                                  type = @Type
                              WHERE accountId = @AccountId";

                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, account);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error while trying to update account with id='{account.AccountId}', email='{account.Email}'. Error was: '{ex.Message}'",
                    ex);
            }
        }
    }
}