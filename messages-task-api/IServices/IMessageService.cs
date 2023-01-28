using messages_task_api.Models;
using messages_task_api.Ressources;

namespace messages_task_api.IServices
{
    public interface IMessageService
    {
        List<MessageResource> Messages(Guid userId);
        Guid AddMessage(PersistMessageResource mess);
    }
}
