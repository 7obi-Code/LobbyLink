using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.APIClient
{
    public class ItemInstanceApiClient(string restUrl) : IFItemInstanceDao
    {
        RestClient _client = new RestClient(restUrl);

        public IEnumerable<ItemInstance> GetAllItemInstances()
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest());
            return response ?? new List<ItemInstance>();
        }

        public IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId)
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest($"account/{accountId}"));
            return response ?? new List<ItemInstance>();
        }

        public ItemInstance GetItemInstanceById(int id)
        {
            var request = new RestRequest($"item/{id}");
            return _client.Get<ItemInstance>(request);
        }
    }
}
