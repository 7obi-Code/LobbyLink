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

        public IEnumerable<ItemInstance> GetAllItemInstances()
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest());
            return response ?? new List<ItemInstance>();
        }

        public IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
