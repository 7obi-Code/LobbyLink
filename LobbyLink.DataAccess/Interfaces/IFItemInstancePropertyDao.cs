using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemInstancePropertyDao
    {
        ItemInstanceProperty? GetItemInstanceProperty(int id);
        IEnumerable<ItemInstanceProperty> GetAllItemInstanceProperties();
    }
}
