using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
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
        
        public async Task<string> AddCustomerAsync(Customer customer)
        {
            string asJson = JsonSerializer.Serialize(customer, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            StringContent content = new StringContent(
                asJson,Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _client.PostAsync($"{path}/createNewCustomer", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            string asJson = JsonSerializer.Serialize(customer);
            StringContent content = new StringContent(asJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PatchAsync($"{path}/updateCustomer", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<Account> GetAccount(string username)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/getAccount?username={username}");
            Console.WriteLine(response.Content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                Account account = JsonSerializer.Deserialize<Account>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return account;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
        
       /* private string HashString(string input)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            var hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var hashedInputAsString = Encoding.ASCII.GetString(hashBytes);
            return hashedInputAsString;
        }*/
    }
}