using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class ItemInstance
    {
        public int ItemInstanceId { get; set; }
        public UserAccount UserAccount { get; set; }
        public int AccountId_FK { get; set; }
        public List<Listing> Listings { get; set; }
        public List<ItemInstancePropertyLine> ItemInstancePropertyLines { get; set; } 
        public ItemDefinition ItemDefinition { get; set; }
        public int ItemDefinitionId_FK { get; set; }
        public ItemInstance(bool status, UserAccount userAccount, int accountId_FK, List<Listing> listings, List<ItemInstancePropertyLine> itemInstancePropertyLines, ItemDefinition? itemDefinition, int itemDefinitionId_FK)
        {
            UserAccount = userAccount;
            AccountId_FK = accountId_FK;
            Listings = listings;
            ItemInstancePropertyLines = itemInstancePropertyLines;
            ItemDefinition = itemDefinition;
            ItemDefinitionId_FK = itemDefinitionId_FK;
        }

        public ItemInstance() { }
    }
}