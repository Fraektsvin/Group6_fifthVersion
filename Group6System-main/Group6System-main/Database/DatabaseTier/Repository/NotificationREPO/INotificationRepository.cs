using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository.NotificationREPO
{
    public interface INotificationRepository
    {
        Task<Notification> GetNotificationAsync(string username);
        Task<Notification> SendNotificationToUserAsync(Notification notification);
    }
}