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
        private string path = "http://localhost:8080";
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{path}/users?username={username}&password={password}");
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("here it is now");
                string asJson = await response.Content.ReadAsStringAsync();
                User login = JsonSerializer.Deserialize<User>(asJson, new JsonSerializerOptions
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