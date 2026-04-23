using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemPropertyLine
{
    public int ItemPropertyLineId { get; set; }

    public ItemDefinition ItemDefinition { get; set; }
    public int ItemDefinitionId { get; set; }
    public ItemProperty ItemProperty { get; set; }  
    public int ItemPropertyId { get; set; }
    public ItemPropertyValue ItemPropertyValue { get; set; }    
    public int ItemPropertyValueId { get; set; }
}
