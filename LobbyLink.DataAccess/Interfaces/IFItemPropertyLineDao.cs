using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemPropertyLineDao
    {
        ItemPropertyLine GetItemPropertyLineById(int id);

        IEnumerable<ItemPropertyLine> GetAllItemPropertyLines();
        IEnumerable<ItemPropertyLine> GetLinesByItemDefinitionId(int itemDefinitionId);

        IEnumerable<ItemPropertyLine> GetLinesByPropertyId(int propertyId);

        int InsertItemPropertyLine(ItemPropertyLine itemPropertyLine);
        bool UpdateItemPropertyLine(ItemPropertyLine itemPropertyLine);
        bool DeleteItemPropertyLine(int id);
    }
}
