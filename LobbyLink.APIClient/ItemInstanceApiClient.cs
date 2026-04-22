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

        public int CreateItemInstance(ItemInstance itemInstance)
        {
            var request = new RestRequest("api/ItemInstance", Method.Post);
            request.AddJsonBody(itemInstance);
            var response = _client.Execute<int>(request);

            if (response.IsSuccessful && response.Data != 0)
            {
                return response.Data;
            }

            throw new Exception($"Failed to insert ItemInstance. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
        }
       

        public IEnumerable<ItemInstance> GetAllItemInstances()
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest());
            return response ?? new List<ItemInstance>();
        }

        public IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId)
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest($"{accountId}"));
            return response ?? new List<ItemInstance>();
        }

        public ItemInstance GetItemInstanceById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
