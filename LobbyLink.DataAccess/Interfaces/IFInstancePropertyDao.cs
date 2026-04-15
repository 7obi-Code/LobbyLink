using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFInstancePropertyDao
    {
        ItemInstanceProperty? GetItemInstanceProperty(int id);
        IEnumerable<ItemInstanceProperty> GetAllItemInstanceProperties();
    }
}
