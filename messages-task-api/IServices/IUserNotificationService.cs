using messages_task_api.Hubs;
using messages_task_api.Models;
using Microsoft.AspNetCore.SignalR;

namespace messages_task_api.IServices
{
    public interface IUserNotificationService
    {
        void IncrementTotal(Guid userId);
        int resetTotal(Guid userId);

        void refresh(UserNotification un);
    }
}
