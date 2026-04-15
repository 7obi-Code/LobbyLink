using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Interfaces
{
    public interface IFItemDefinitionDao
    {
        ItemDefinition? GetItemDefinitionById(int id);
        IEnumerable<ItemDefinition> GetAllItemDefinitions();
        int InsertItemDefinition(ItemDefinition itemDefinition);
        bool UpdateItemDefiniton(ItemDefinition itemDefinition);
        bool DeleteItemDefiniton(int id);
    }
}
