using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.AccountService
{
    public class AccountService : IAccount
    {
        private readonly HttpClient _client = new HttpClient();
        private string path = "http://localhost:8080";


        public async Task AddAccount(Account account)
        {
            string AsJson = JsonSerializer.Serialize(account, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });


            StringContent content = new StringContent(
                AsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync($"{path}/createNewAccount", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}
    
