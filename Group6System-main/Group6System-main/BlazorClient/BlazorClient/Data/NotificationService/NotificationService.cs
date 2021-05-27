using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.NotificationService
{
    public class NotificationService:INotificationService
    {
        private readonly HttpClient _client = new HttpClient();
        private string path = "http://localhost:8080";

        public async Task<Notification> GetNotificationFromAdminAsync(string username)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/getNotification");
            //We might need to use another path i think we are using this path somewhere else I am not sure
            if (response.IsSuccessStatusCode)
            {
                string asJson = await response.Content.ReadAsStringAsync();
                Notification  message = JsonSerializer.Deserialize<Notification>(asJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return message;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public async Task SendNotificationToUserAsync(string username)
        {
            string asJson = JsonSerializer.Serialize(username, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            StringContent content = new StringContent(
                asJson,Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _client.PostAsync($"{path}/sendNotification", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
    }
}