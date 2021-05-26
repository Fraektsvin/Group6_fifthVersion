using System;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTier.Repository.NotificationREPO
{
    public class NotificationRepository:INotificationRepository
    {
        public async Task<Notification> GetNotificationAsync(string username)
        {
            await using CloudContext context = new CloudContext();
            Notification newNotification = await context.NotificationTable.Include(a => a.Customer).ThenInclude(a=> a.User)
                .FirstOrDefaultAsync(a => a.Customer.User.Username.Equals(username));
            return newNotification;
        }

        public async Task<Notification> SendNotificationToUserAsync(Notification notification)
        {
            using (CloudContext context = new CloudContext())
            {
                try
                {
                    var toSend = await context.NotificationTable.AddAsync(notification);
                     await context.SaveChangesAsync();
                    return toSend.Entity;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    throw new Exception($"Could not send!");
                }
            }
        }
    }
}