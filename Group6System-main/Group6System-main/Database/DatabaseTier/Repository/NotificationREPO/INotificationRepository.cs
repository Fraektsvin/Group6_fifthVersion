using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository.NotificationREPO
{
    public interface INotificationRepository
    {
        Task<IList<Notification>> GetNotificationAsync();
        Task<Notification> SendNotificationToUserAsync(Notification notification);
    }
}