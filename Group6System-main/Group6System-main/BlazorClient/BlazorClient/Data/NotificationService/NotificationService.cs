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
            HttpResponseMessage response = await _client.GetAsync($"{path}/getNotification?username={username}");
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
    }
}