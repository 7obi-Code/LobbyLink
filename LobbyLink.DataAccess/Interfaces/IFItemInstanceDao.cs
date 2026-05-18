using LobbyLink.DataAccess.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemInstanceDao
    {
        IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId);
        ItemInstance GetItemInstanceById(int id);
        int CreateItemInstance(ItemInstance itemInstance);

    }
}
