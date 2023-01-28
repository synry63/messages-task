using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace messages_task_api.Models
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Body { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string SenderEmail{ get; set; }
        public DateTime DateReceived { get; set; }
        
        public virtual User User { get; set; } //recipient user
        public Guid UserId { get; set; }

    }
}
