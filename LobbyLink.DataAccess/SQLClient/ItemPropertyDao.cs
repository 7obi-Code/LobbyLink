using LobbyLink.DataAccess.SQLClient;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ItemPropertyDao : BaseDao, IFItemPropertyDao
    {
        public ItemPropertyDao(string connectionString) : base(connectionString) { }

        public void DeleteItemProperty(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemProperty> GetAllItemProperties()
        {
            throw new NotImplementedException();
        }

        public ItemProperty? GetItemPropertyById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertItemProperty(ItemProperty itemProperty)
        {
            throw new NotImplementedException();
        }

        public void UpdateItemProperty(ItemProperty itemProperty)
        {
            throw new NotImplementedException();
        }
    }
}
