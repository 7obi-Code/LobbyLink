using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemPropertyValue
{
    public int ItemPropertyValueId { get; set; }
    public string Value { get; set; }
    public ItemProperty ItemProperty { get; set; }
    public int ItemPropertyId { get; set; }
    public ItemPropertyValue() { }
}
