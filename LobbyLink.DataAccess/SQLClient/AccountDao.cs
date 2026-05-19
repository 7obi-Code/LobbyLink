using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using System.Security.Principal;

namespace LobbyLink.DataAccess.SQLClient;

public class AccountDao : BaseDao, IFAccountDao
{
    public AccountDao(string connectionString) : base(connectionString) { }

    //DAO metode til at slette bruger ud fra Id
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

    //DAO metode finde alle accounts
    public IEnumerable<Account> GetAllAccounts()
    {
        try
        {
            var query = @"SELECT * FROM Account";

            using var connection = CreateConnection();
            return connection.Query<Account>(query);
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Error getting all accounts. Error: '{ex.Message}'", ex);
        }
    }

    //DAO metode til at finde en account ud fra et Id
    public Account? GetAccountById(int id)
    {
        try
        {
            var query = @"SELECT * FROM Account
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

    //DAO metode til at indsætte en account i databasen
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

    //DAO metode til at opdatere en account ud fra et account objekt
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

    //DAO metode til at finde et accountId ud fra en email
    public int GetAccountIdByEmail(string email)
    {
        using var connection = CreateConnection();
        try
        {
            var query = @"SELECT accountId 
                          FROM Account 
                          WHERE email = @Email";

            int result = connection.ExecuteScalar<int>(query, new { Email = email });

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Error getting accountId from email:{email}. Error: '{ex.Message}'", ex);
        }
    }
}