using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemInstanceDao
    {
        ItemInstance? GetItemInstance(int id);
        IEnumerable<ItemInstance> GetAllItemInstances();
    }
}
