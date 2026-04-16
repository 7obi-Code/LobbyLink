using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class UserAccount : Account
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Level { get; set; }
        public Wallet Wallet { get; set; }
        public List<Game> Games { get; set; }
        public List<Listing> Listings { get; set; }
        public List <ItemInstance> ItemInstances { get; set; }

        public UserAccount(int userId, string userName, int level, Wallet wallet, List<Game> games, List<Listing> listings, List<ItemInstance> itemInstances)
        {
            UserId = userId;
            UserName = userName;
            Level = level;
            Wallet = wallet;
            Games = games;
            Listings = listings;
            ItemInstances = itemInstances;
        }

        public UserAccount() { }
    }
}