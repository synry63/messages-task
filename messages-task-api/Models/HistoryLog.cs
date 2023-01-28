using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace messages_task_api.Models
{
    [Table("HistoryLogs")]
    public class HistoryLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int TypeLog { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
