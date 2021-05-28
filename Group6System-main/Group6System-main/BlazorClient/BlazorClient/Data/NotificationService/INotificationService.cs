using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.NotificationService
{
    public interface INotificationService
    {
        Task<IList<Notification>> GetNotificationFromAdminAsync(string username);
    }
}