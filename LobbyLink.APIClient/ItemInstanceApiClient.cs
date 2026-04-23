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
            var request = new RestRequest("api/v1/iteminstance", Method.Post);
            request.AddJsonBody(itemInstance);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return int.Parse(response.Content);
            }

            throw new Exception(
                $"Failed to insert ItemInstance.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }


        public IEnumerable<ItemInstance> GetAllItemInstances()
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest("api/v1/ItemInstance"));
            return response ?? new List<ItemInstance>();
        }

        public IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId)
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest($"api/v1/ItemInstance/account/{accountId}"));
            return response ?? new List<ItemInstance>();
        }

        public ItemInstance GetItemInstanceById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
