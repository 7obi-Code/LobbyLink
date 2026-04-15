using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemPropertyValueDao
    {
        ItemPropertyValue? GetItemPropertyValueById(int id);

        IEnumerable<ItemPropertyValue> GetAllItemPropertyValues();


        int InsertItemPropertyValue(ItemPropertyValue itemPropertyValue);
        bool UpdateItemPropertyValue(ItemPropertyValue itemPropertyValue);
        bool DeleteItemPropertyValue(int id);
    }
}
