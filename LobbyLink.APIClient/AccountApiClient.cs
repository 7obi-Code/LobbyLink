using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;

namespace LobbyLink.APIClient
{
    public class AccountApiClient(string restUrl) : IFAccountDao
    {
        RestClient _client = new RestClient(restUrl);

        //Metoder som sender HTTP request til vores API Server
        
        //Delete account sender "id" ind til endpointet der sletter en account
        public bool DeleteAccount(int id)
        {
            var request = new RestRequest($"{id}", Method.Delete);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                return bool.Parse(response.Content);
            }

            throw new Exception(
                $"Failed to delete Account.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }

        //GetAccountIdByEmail sender "email" til endpointet der fremfinder en brugers id baseret på en email.
        public int GetAccountIdByEmail(string email)
        {
            var request = new RestRequest($"idByEmail", Method.Get);
            request.AddQueryParameter("email", email);

            var response = _client.Execute<int>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            throw new Exception(
                $"Failed to get accountId from email: {email}.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }

        //GetAllAccounts sender request til endpointet der fremfinder alle accounts
        public IEnumerable<Account> GetAllAccounts()
        {
            var request = new RestRequest("", Method.Get);

            var response = _client.Execute<List<Account>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            throw new Exception(
                $"Failed to get all Accounts.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }

        //InsertAccount sender en POST request ud fra account objektet som bliver konverteret til JSON.
        public int InsertAccount(Account account)
        {
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(account);

            var response = _client.Execute<Account>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return int.Parse(response.Content);
            }

            throw new Exception(
                $"Failed to insert Account.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }
    }
}
