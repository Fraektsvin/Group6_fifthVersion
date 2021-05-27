using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.NotificationService
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationFromAdminAsync(string username); 
        Task SendNotificationToUserAsync(string username); 
    }
}