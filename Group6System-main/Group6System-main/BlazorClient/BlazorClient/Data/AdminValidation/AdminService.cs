using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.AdminValidation
{
    public class AdminService:IAdminService
    {
        private string path = "http://localhost:8080";
        HttpClient client = new HttpClient();
        
        public async Task ValidateCustomerAsync(Customer customer)
        {
            string asJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(
                asJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{path}/validateCustomer", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            }
        }
        
        public async Task RemoveCustomerAsync(int cprNumber)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{path}/removeCustomer/{cprNumber}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            HttpResponseMessage response = await client.GetAsync($"{path}/getCustomers");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                IList<Customer> customers = JsonSerializer.Deserialize<IList<Customer>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return customers;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<string> CreateAccountAsync(string username)
        {
            HttpResponseMessage response = await client.GetAsync($"{path}/CreateAccount?username={username}");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

                return result;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
    }
}