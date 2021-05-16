using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data
{
    public class Notification
    {
        /*private readonly HttpClient _client = new HttpClient();
        private string path = "http://localhost:8080";

        public async Task<String> GetNotifications(User username)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/users?username={username}");
            if (response.IsSuccessStatusCode)
            {
                string asJson = await response.Content.ReadAsStringAsync();
                String message = JsonSerializer.Deserialize<String>(asJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return message;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }*/
    }
}