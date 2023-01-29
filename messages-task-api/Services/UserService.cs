using Castle.Core.Resource;
using Elfie.Serialization;
using messages_task_api.Hubs;
using messages_task_api.IServices;
using messages_task_api.Models;
using messages_task_api.Ressources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace messages_task_api.Services
{
    public sealed class UserService : IUserService
    {
        private readonly MessagesTaskContext _context;
        private readonly IUserNotificationService _userNotificationService;
        private readonly string _pepper;
        private readonly int _iteration = 3;


        public UserService(MessagesTaskContext context, IUserNotificationService userNotificationService)
        {
            _context = context;
            _pepper = "ab$45";
            _userNotificationService = userNotificationService;
        }

        public UserProfilResource Login(RegisterResource resource)
        {
            var user = _context.Users.Where(x => x.Email == resource.Email)
                        .Include(x => x.userNotification)
                        .FirstOrDefault();
            if(user == null)
            {
                return null;
            }
            else
            {
                var passwordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _pepper, _iteration);
                if (user.PasswordHash != passwordHash)
                {
                    return null;
                }
                var total = 0;
                if (user.userNotification != null) //set notif to 0 as news messages will be display at login
                {
                    total = _userNotificationService.resetTotal(user.Id);
                }

                return new UserProfilResource(user.Id, user.Email, total);
                
                    
            }

        }
        public bool Logout(UserResource resource)
        {
            var user = _context.Users.Find(resource.Id);
            if (user != null)
            {
                return true;
            }
            return false;

        }

        public UserProfilResource Register(RegisterResource resource)
        {

            var user = _context.Users.FirstOrDefault(x => x.Email == resource.Email);
            if(user == null)
            {
                var newUser = new User
                {
                    Email = resource.Email,
                    PasswordSalt = PasswordHasher.GenerateSalt()
                };
                newUser.PasswordHash = PasswordHasher.ComputeHash(resource.Password, newUser.PasswordSalt, _pepper, _iteration);
                _context.Users.Add(newUser);
                _context.SaveChanges();

                return new UserProfilResource(newUser.Id, newUser.Email,0);
            }
            else
            {
                return null;
            }

            
        }

        public User User(Guid id)
        {
            var user = _context.Users.Find(id);

            return user;

        }

        public List<UserResource> Users()
        {
            var usersRessource = new List<UserResource>();
            _context.Users.ToList().ForEach((Action<User>)(i => {
                usersRessource.Add(new UserResource(i.Id, i.Email));
            }));
            return usersRessource;

        }
    }
}
