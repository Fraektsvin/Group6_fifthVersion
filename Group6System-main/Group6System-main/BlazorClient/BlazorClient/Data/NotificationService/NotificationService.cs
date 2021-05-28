using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace BlazorClient.Data.NotificationService
{
    public class NotificationService:INotificationService
    {
        private readonly HttpClient _client = new HttpClient();
        private string path = "http://localhost:8080";

        public async Task<IList<Notification>> GetNotificationFromAdminAsync(string username)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/getNotification?username={username}");
            if (response.IsSuccessStatusCode)
            {
                string asJson = await response.Content.ReadAsStringAsync();
                IList<Notification> notifications = JsonSerializer.Deserialize<IList<Notification>>(asJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return notifications;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
    }
}