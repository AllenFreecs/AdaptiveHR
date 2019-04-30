using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdaptiveHR.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserBL _userBL;

        public AuthController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(string UserName , string Password)
        {
            var user = _userBL.Authenticate(UserName, Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        [Route("heartbeat")]
        public IActionResult HeartBeat()
        {
            string claimid = User.FindFirstValue(ClaimTypes.Name);
            return Ok(claimid);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userBL.GetAll();
            return Ok(users);
        }
    }
}