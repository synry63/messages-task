using Microsoft.AspNetCore.Mvc;
using messages_task_api.Ressources;
using messages_task_api.IServices;

namespace messages_task_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHistoryLogService _historyLogService;

        public UsersController(IUserService userService, IHistoryLogService historyLogService)
        {
            _userService = userService;
            _historyLogService = historyLogService;
        }
        
        // GET: api/Users
        [HttpGet]
        public  ActionResult<IEnumerable<UserResource>> GetUsers()
        {
            var response = _userService.Users();

            return response;
        }
       
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public  ActionResult<UserProfilResource> Register(RegisterResource resource)
        {
            var response = _userService.Register(resource);

            if(response == null)
            {
                return Conflict();
            }
            _historyLogService.AddloginLog(response.Id);
            return Ok(response);
        }
        // POST: api/Users
        [HttpPost("login")]
        public ActionResult<UserProfilResource> Login(RegisterResource resource)
        {
            var response = _userService.Login(resource);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                _historyLogService.AddloginLog(response.Id);
                return Ok(response);
            }


        }
        // POST: api/Users
        [HttpPost("logout")]
        public ActionResult<bool> logout(UserResource resource)
        {
            var response = _userService.Logout(resource);
            if (response)
            {
                _historyLogService.AddLogoutLog(resource.Id);
            }
            return Ok(response);


        }

    }
}
