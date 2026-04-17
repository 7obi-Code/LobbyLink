using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class ItemInstance
    {
        public int ItemInstanceId { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
        public List<Listing> Listings { get; set; }
        public List<ItemInstancePropertyLine> ItemInstancePropertyLines { get; set; } 
        public ItemDefinition ItemDefinition { get; set; }
        public int ItemDefinitionId { get; set; }

        public ItemInstance() { }
    }
}