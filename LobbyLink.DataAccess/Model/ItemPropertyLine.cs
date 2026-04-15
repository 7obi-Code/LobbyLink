using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model;
public class ItemPropertyLine
{
    public int Id { get; set; }

    public int ItemDefinitionId { get; set; }
    public int ItemPropertyId { get; set; }
    public int ItemPropertyValueId { get; set; }
}
