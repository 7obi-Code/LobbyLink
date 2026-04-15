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
    public List<ItemPropertyLine> ItemPropertyLines { get; set; }

    public ItemDefinition(int itemDefinitionId, string itemName, string itemImageUrl, string itemDescription, Game gameDefinition, List<ItemPropertyLine> itemPropertyLines)
    {
        ItemDefinitionId = itemDefinitionId;
        ItemName = itemName;
        ItemImageUrl = itemImageUrl;
        ItemDescription = itemDescription;
        GameDefinition = gameDefinition;
        ItemPropertyLines = itemPropertyLines;
    }
}
