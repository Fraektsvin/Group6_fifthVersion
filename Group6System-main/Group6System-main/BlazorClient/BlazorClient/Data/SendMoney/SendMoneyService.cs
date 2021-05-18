using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.SendMoney
{
    public class SendMoneyService : ISendMoneyService
    {
        private string path = "http://localhost:8080";
        private HttpClient client = new HttpClient();

        public async Task<String> PayBillAsync(Transaction transaction)
        {
            string AsJson = JsonSerializer.Serialize(transaction, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            StringContent content = new StringContent(
                AsJson,Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync($"{path}/paybill", content);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<string> SendMoney(Transaction transaction)
        {
            string AsJson = JsonSerializer.Serialize(transaction, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            StringContent content = new StringContent(
                AsJson,Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync($"{path}/sendmoney", content);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
    }
}
