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
using messages_task_api.IServices;

namespace messages_task_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotificationsController : ControllerBase
    {
        private readonly IUserNotificationService _userNotificationService;

        public UserNotificationsController(IUserNotificationService userNotificationService)
        {
            _userNotificationService = userNotificationService;
        }

        // POST: api/UserNotifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("reset")]
        public ActionResult<int> Reset(UserNotificationResource resource)
        {
            var result = _userNotificationService.resetTotal(resource.UserId);
            return Ok(result);
        }

     
    }
}
