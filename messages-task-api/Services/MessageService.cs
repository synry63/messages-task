using messages_task_api.IServices;
using messages_task_api.Models;
using messages_task_api.Ressources;

namespace messages_task_api.Services
{
    public sealed class MessageService : IMessageService
    {
        private readonly MessagesTaskContext _context;
        private readonly IUserNotificationService _userNotificationService;


        public MessageService(MessagesTaskContext context, IUserNotificationService userNotificationService)
        {
            _context = context;
            _userNotificationService = userNotificationService;
        }

        public Guid AddMessage(PersistMessageResource mess)
        {
            var message = new Message
            {
                Body = mess.Body,
                SenderEmail = mess.SenderEmail,
                UserId = mess.UserId,
                DateReceived = DateTime.UtcNow,
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            _userNotificationService.IncrementTotal(message.UserId);

            return message.Id;
        }

        public List<MessageResource> Messages(Guid userId)
        {
            var messagesRessource = new List<MessageResource>();
            _context.Messages.Where(x => x.UserId==userId).OrderByDescending(x => x.DateReceived).ToList().ForEach(i => {
                messagesRessource.Add(new MessageResource(i.Id,i.SenderEmail, i.Body));
            });

            return messagesRessource;
        }
    }
}
