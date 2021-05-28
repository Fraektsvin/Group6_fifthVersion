using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTier.Repository.NotificationREPO
{
    public class NotificationRepository:INotificationRepository
    {
        public async Task<IList<Notification>> GetNotificationAsync()
        {
            using (CloudContext context = new CloudContext())
            {
                try
                {
                    IList<Notification> notifications = await context.NotificationTable
                        .Include(u => u.User).ToListAsync();

                    return notifications;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<Notification> SendNotificationToUserAsync(Notification notification)
        {
            await using CloudContext context = new CloudContext();
            try
            {
                var user = await context.UsersTable.FirstOrDefaultAsync(u =>
                    u.Username.Equals(notification.User.Username));
                if (user != null)
                {
                    notification.User = user;
                }
                var toSend = await context.NotificationTable.AddAsync(notification);
                await context.SaveChangesAsync();
                return toSend.Entity;
                
            }
            catch (Exception e)
            {

                throw new Exception($"Could not send!");
            }
        }
    }
}