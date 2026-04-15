using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class ItemInstancePropertyLine
    {
        public int ItemInstancePropertyLineId { get; set; }
        public string Value { get; set; }

        public ItemInstancePropertyLine(int itemInstancePropertyLineId, string value)
        {
            ItemInstancePropertyLineId = itemInstancePropertyLineId;
            Value = value;
            
        }
    }
}
