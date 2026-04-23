using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class ItemInstancePropertyLine
    {
        public int ItemInstancePropertyLineId { get; set; }
        public string Value { get; set; }

        public ItemInstanceProperty ItemInstanceProperty { get; set; }
        public int ItemInstancePropertyId { get; set; }
        public ItemInstance ItemInstance { get; set; }
        public int ItemInstanceId { get; set; }

        public ItemInstancePropertyLine() { }
    }
}
