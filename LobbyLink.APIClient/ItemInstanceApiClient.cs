using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.APIClient
{
    public class ItemInstanceApiClient : IFItemInstanceDao
    {
        RestClient _client;

        public ItemInstanceApiClient(string restUrl)
        {
            _client = new RestClient(restUrl);
        }

        public bool DeleteItemInstanceById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInstance> GetAllItemInstances()
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest());
            return response ?? new List<ItemInstance>();
        }

        public IEnumerable<ItemInstance> GetAllItemInstancesByUserId()
        {
            throw new NotImplementedException();
        }

        public ItemInstance? GetItemInstanceById(int id)
        {
            throw new NotImplementedException();
        }

        public int InsertItemInstance(ItemInstance itemInstance)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemInstance(ItemInstance itemInstance)
        {
            throw new NotImplementedException();
        }
    }
}
