using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using messages_task_api;
using messages_task_api.Models;
using messages_task_api.Ressources;
using Elfie.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using messages_task_api.Hubs;
using Microsoft.AspNetCore.SignalR;
using messages_task_api.IServices;

namespace messages_task_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserNotificationService _userNotificationService;

        public MessagesController(IMessageService messageService, IUserNotificationService userNotificationService)
        {
            _messageService = messageService;
            _userNotificationService = userNotificationService;
        }

        // GET: api/Messages
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<MessageResource>> GetMessages(Guid userId)
        {
            var response = _messageService.Messages(userId);

            return response;
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Message> PostMessage(PersistMessageResource ressource)
        {
            var response = _messageService.AddMessage(ressource);
            _userNotificationService.IncrementTotal(ressource.UserId);

            return Ok(response);
        }

    }
}
