using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace messages_task_api.Models
{
    [Table("UserNotifications")]
    public class UserNotification
    {
        [ForeignKey("User")]
        public Guid Id { get; set; }
        //public Guid UserNotificationId { get; set; }
        public int Total { get; set; }
        public virtual User User { get; set; }
    }
}
