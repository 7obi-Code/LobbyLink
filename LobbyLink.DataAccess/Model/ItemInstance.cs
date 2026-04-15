using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class ItemInstance
    {
        public int ItemInstanceId { get; set; }
        public bool Status { get; set; }
        public UserAccount UserAccount { get; set; }
        public List<Listing> Listings { get; set; }
        public List<ItemInstancePropertyLine> ItemInstancePropertyLines { get; set; } 
        public ItemDefinition ItemDefinition { get; set; }  
        public ItemInstance(int itemInstanceId, bool status, UserAccount userAccount, List<Listing> listings, List<ItemInstancePropertyLine> itemInstancePropertyLines, ItemDefinition? itemDefinition)
        {
            ItemInstanceId = itemInstanceId;
            Status = status;
            UserAccount = userAccount;
            Listings = listings;
            ItemInstancePropertyLines = itemInstancePropertyLines;
            ItemDefinition = itemDefinition;
        }

        public ItemInstance() { }
    }
}