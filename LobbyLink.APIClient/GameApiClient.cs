using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using RestSharp;
using System;
using System.Collections.Generic;

namespace LobbyLink.APIClient
{
    public class GameApiClient(string restUrl) : IFGameDao
    {
        private readonly RestClient _client = new RestClient(restUrl);

        //GetAllGames sender request til endpointet der finder alle Games.
        public IEnumerable<Game> GetAllGames()
        {
            var request = new RestRequest("", Method.Get);

            var response = _client.Execute<List<Game>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            throw new Exception(
                $"Failed to get Games.\n" +
                $"Status: {response.StatusCode}\n" +
                $"Response: {response.Content}"
            );
        }
    }
}