using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class Game
{
    public int GameId { get; set; }
    public string GameTitle { get; set; }
    public string GameStudio { get; set; }
    public List<ItemDefinition> ItemDefinitons { get; set; }
}
