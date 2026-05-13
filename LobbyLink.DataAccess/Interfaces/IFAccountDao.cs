using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFAccountDao
    {
        IEnumerable<Account> GetAllAccounts();
        int InsertAccount(Account account);
        int GetAccountIdByEmail(string email);
    }
}
