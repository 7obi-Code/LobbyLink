using LobbyLink.DataAccess.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemInstanceDao
    {
        ItemInstance? GetItemInstanceById(int id);
        IEnumerable<ItemInstance> GetAllItemInstance();
        int InsertItemInstance(ItemInstance itemInstance);
        bool UpdateItemInstance(ItemInstance itemInstance);
        bool DeleteItemInstanceById(int id);
    }
}
