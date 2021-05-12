using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.CustomerService
{
    public class CustomerService:ICustomerService
    {
        private readonly HttpClient _client = new HttpClient();
        private string path = "http://localhost:8080";
        
        public async Task AddCustomerAsync(Customer user)
        {
            string AsJson = JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            
            StringContent content = new StringContent(
                AsJson,Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _client.PostAsync($"{path}/createNewUser", content);
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