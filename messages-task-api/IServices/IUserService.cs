using messages_task_api.Models;
using messages_task_api.Ressources;

namespace messages_task_api.IServices
{
    public interface IUserService
    {
        List<UserResource> Users();
        User User(Guid id);
        UserProfilResource Register(RegisterResource resource);
        UserProfilResource Login(RegisterResource resource);
        bool Logout(UserResource resource);
    }
}
