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

        void InsertItemProperty(ItemProperty itemProperty);
        void UpdateItemProperty(ItemProperty itemProperty);
        void DeleteItemProperty(int id);
    }
}
