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
    public Game? Game { get; set; }
    public int GameId { get; set; }
    public List<ItemInstance>? ItemInstances { get; set; }

    public ItemDefinition() { }

}
