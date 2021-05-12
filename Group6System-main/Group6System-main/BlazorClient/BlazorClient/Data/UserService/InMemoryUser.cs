using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.UserService
{
    public class InMemoryUser: IUserService
    {
        private readonly HttpClient _client = new HttpClient();
        private string path = "http://localhost:8080";

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/users?username={username}&password={password}");
            if (response.IsSuccessStatusCode)
            {
                string AsJson = await response.Content.ReadAsStringAsync();
                User login = JsonSerializer.Deserialize<User>(AsJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine("Successfully logged in");
                return login;
            }
            
            throw new Exception($"{HttpStatusCode.NotFound}");
        }
    }
}