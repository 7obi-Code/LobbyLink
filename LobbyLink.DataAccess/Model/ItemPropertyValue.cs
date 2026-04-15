using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemPropertyValue
{
    public int Id { get; set; }
    public string Value { get; set; }
    public ItemPropertyValue(int id, string value)
    {
        Id = id;
        Value = value;
    }
}
