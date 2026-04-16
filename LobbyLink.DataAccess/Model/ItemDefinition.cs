using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemDefinition
{
    public int ItemDefinitionId { get; set; }    
    public string ItemName { get; set; }
    public string ItemImageUrl { get; set; }
    public string ItemDescription { get; set; }
    public Game GameDefinition { get; set; }
    public int GameId_FK { get; set; }
    public List<ItemPropertyLine> ItemPropertyLines { get; set; }

    public ItemDefinition(int itemDefinitionId, string itemName, string itemImageUrl, string itemDescription, int gameId_FK, Game gameDefinition, List<ItemPropertyLine> itemPropertyLines)
    {
        ItemDefinitionId = itemDefinitionId;
        ItemName = itemName;
        ItemImageUrl = itemImageUrl;
        ItemDescription = itemDescription;
        GameId_FK = gameId_FK;
        GameDefinition = gameDefinition;
        ItemPropertyLines = itemPropertyLines;

    }
}
