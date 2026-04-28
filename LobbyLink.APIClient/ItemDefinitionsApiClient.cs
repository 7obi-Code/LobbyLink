using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;
using System;
using System.Collections.Generic;

namespace LobbyLink.APIClient
{
    public class ItemDefinitionsApiClient(string restUrl) : IFItemDefinitionDao
    {
        private readonly RestClient _client = new RestClient(restUrl);

        public IEnumerable<ItemDefinition> GetAllItemDefinitions()
        {
            var request = new RestRequest("", Method.Get);

            var response = _client.Execute<List<ItemDefinition>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            throw new Exception(
                $"Failed to get ItemDefinitions.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }

        public ItemDefinition? GetItemDefinitionById(int id)
        {
            var request = new RestRequest($"{id}", Method.Get);

            var response = _client.Execute<ItemDefinition>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            throw new Exception(
                $"Failed to get ItemDefinition.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }

        public int InsertItemDefinition(ItemDefinition itemDefinition)
        {
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(itemDefinition);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return int.Parse(response.Content);
            }

            throw new Exception(
                $"Failed to insert ItemDefinition.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }

        public bool UpdateItemDefinition(ItemDefinition itemDefinition)
        {
            var request = new RestRequest("", Method.Put);
            request.AddJsonBody(itemDefinition);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return bool.Parse(response.Content);
            }

            throw new Exception(
                $"Failed to update ItemDefinition.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }

        public bool DeleteItemDefinition(int id)
        {
            var request = new RestRequest($"{id}", Method.Delete);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return bool.Parse(response.Content);
            }

            throw new Exception(
                $"Failed to delete ItemDefinition.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }
    }
}