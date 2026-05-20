using LobbyLink.DataAccess.Model;
using RestSharp;

namespace LobbyLink.APIClient
{
    public class ItemDefinitionApiClient(string restUrl)
    {
        private readonly RestClient _client = new RestClient(restUrl);

        //Sender request til API endpointet der finder alle ItemDefinitions
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

        //Request til at finde en ItemDefinitions ud fra Id
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

        //Request til at indsætte en ItemDefinition ud fra et objekt af typen ItemDefinition
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

        //Request til at opdatere en ItemDefinition
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

        //Request til at slette en ItemDefinition ud fra et Id
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