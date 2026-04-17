using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemInstanceProperty
{
    public string ItemInstancePropertyId { get; set; }    
    public string ItemInstancePropertyName { get; set; }

    public Game Game { get; set; }
    public int GameId { get; set; }

    public ItemInstanceProperty() { }

}
