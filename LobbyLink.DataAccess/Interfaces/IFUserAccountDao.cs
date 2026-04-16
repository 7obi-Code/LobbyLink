using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFUserAccountDao
    {
        UserAccount? GetUserAccountById(int id);
        IEnumerable<UserAccount> GetAllUserAccounts();
    }
}
