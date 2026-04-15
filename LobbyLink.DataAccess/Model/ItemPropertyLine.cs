using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemPropertyLine
{
    public int Id { get; set; }
    public ItemDefinition ItemDefiniton { get; set; }
    public ItemProperty ItemProperty { get; set; }
    public ItemPropertyValue ItemPropertyValue { get; set; }
}
