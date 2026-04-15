using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemInstanceProperty
{
 

    public string ItemInstancePropertyName { get; set; }    
    public string ItemInstancePropertyValue { get; set; }

    public ItemInstanceProperty(string itemInstancePropertyName, string itemInstancePropertyValue)
    {
        ItemInstancePropertyName = itemInstancePropertyName;
        ItemInstancePropertyValue = itemInstancePropertyValue;
    }

}
