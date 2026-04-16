using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    internal interface IFItemInstancePropertyLineDao
    {
        ItemInstancePropertyLine? GetItemInstancePropertyLineById(int id);
        IEnumerable<ItemInstancePropertyLine> GetAllItemInstancePropertyLines();
        int InsertItemInstancePropertyLine(ItemInstancePropertyLine itemInstancePropertyLine);
        bool UpdateItemInstancePropertyLine(ItemInstancePropertyLine itemInstancePropertyLine);
        bool DeleteItemInstancePropertyLine(int id);
    }
}
