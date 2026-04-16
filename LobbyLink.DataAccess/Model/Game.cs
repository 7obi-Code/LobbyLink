using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class Game
{
    public int GameId { get; set; }
    public string GameTitle { get; set; }
    public string GameStudio { get; set; }
    public List<ItemProperty> ItemProperties { get; set; }
    public List<ItemInstanceProperty> ItemInstanceProperties { get; set; }
    public List<ItemDefinition> ItemDefinitons { get; set; }
    public Game(int gameId, string gameTitle, string gameStudio, List<ItemProperty> itemProperties, List<ItemInstanceProperty> itemInstanceProperties, List<ItemDefinition> itemDefinitons)
    {
        GameId = gameId;
        GameTitle = gameTitle;
        GameStudio = gameStudio;
        ItemProperties = itemProperties;
        ItemInstanceProperties = itemInstanceProperties;
        ItemDefinitons = itemDefinitons;
    }
}
