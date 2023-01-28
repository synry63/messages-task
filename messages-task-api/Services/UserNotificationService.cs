using messages_task_api.Hubs;
using messages_task_api.IServices;
using messages_task_api.Models;
using Microsoft.AspNetCore.SignalR;
using System;

namespace messages_task_api.Services
{
    public sealed class UserNotificationService : IUserNotificationService
    {
        private readonly MessagesTaskContext _context;
        private readonly IHubContext<MessageHub> _hubContext;

        public UserNotificationService(MessagesTaskContext context, IHubContext<MessageHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;

        }
        public void IncrementTotal(Guid userId)
        {
            var un = _context.UserNotifications.Find(userId);
            if (un != null)
            {
                un.Total++;
                _context.UserNotifications.Update(un);
            }
            else
            {
                var newUn = new UserNotification
                {
                    Total = 1,
                    Id = userId,
                };
                _context.UserNotifications.Add(newUn);
                un = newUn;
            }
            _context.SaveChanges();
            this.refresh(un);

        }

        public void refresh(UserNotification un)
        {
            _hubContext
              .Clients
              .All
              .SendAsync("MessageChange", un.Total,un.Id);
        }

        public int resetTotal(Guid userId)
        {
            var un = _context.UserNotifications.Find(userId);
            int total = 0;
            if(un != null)
            {
                un.Total = total;
                _context.UserNotifications.Update(un);
                _context.SaveChanges();
            }
            
            return total;
        }
    }
}
