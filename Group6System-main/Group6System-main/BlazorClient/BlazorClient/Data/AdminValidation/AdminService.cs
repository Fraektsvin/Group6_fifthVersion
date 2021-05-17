using System;
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
        
        public async Task ValidateCustomerAsync(Customer customer)
        {
            HttpClient client = new HttpClient();
            string asJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(
                asJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{path}/customers", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task CreateCustomerAccountAsync(Customer customer, Account account)
        {
            HttpClient client = new HttpClient();
            string asJson = JsonSerializer.Serialize(account);
            HttpContent content = new StringContent(
                asJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response =
                await client.PostAsync($"{path}/customers?cprNumber={customer.CprNumber}", content);
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