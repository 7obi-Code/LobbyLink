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

        //Request til at oprette en ItemInstance ud fra et objekt af typen ItemInstance
        public int CreateItemInstance(ItemInstance itemInstance)
        {
            var request = new RestRequest("", Method.Post);
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

        //Request til at finde alle ItemInstances ud fra et bruger id
        public IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId)
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest($"account/{accountId}"));
            return response ?? new List<ItemInstance>();
        }

        //Request til at finde alle ItemInstances
        public IEnumerable<ItemInstance> GetAllItemInstances()
        {
            var response = _client.Get<IEnumerable<ItemInstance>>(new RestRequest($""));
            return response ?? new List<ItemInstance>();
        }

        //Request til at finde en ItemInstance ud fra et Id
        public ItemInstance? GetItemInstanceById(int id)
        {
            var request = new RestRequest($"{id}");
            var response = _client.Execute<ItemInstance>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            return null;
        }
    }
}
