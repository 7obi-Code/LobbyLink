using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemPropertyDao
    {
        ItemProperty? GetItemPropertyById(int id);
        IEnumerable<ItemProperty> GetAllItemProperties();

        int InsertItemProperty(ItemProperty itemProperty);
        bool UpdateItemProperty(ItemProperty itemProperty);
        bool DeleteItemProperty(int id);
    }
}
