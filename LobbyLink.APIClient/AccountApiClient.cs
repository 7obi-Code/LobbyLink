using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;

namespace LobbyLink.APIClient
{
    public class AccountApiClient(string restUrl) : IFAccountDao
    {
        RestClient _client = new RestClient(restUrl);

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
