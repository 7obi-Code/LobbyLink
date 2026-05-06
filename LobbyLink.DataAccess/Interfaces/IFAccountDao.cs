using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFAccountDao
    {
        Account? GetAccountById(int id);
        IEnumerable<Account> GetAllAccounts();
        int InsertAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(int id);
        int GetAccountIdByEmail(string email);
    }
}
