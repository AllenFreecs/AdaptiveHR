using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.User;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

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
        [ProducesResponseType(typeof(UserInfo), 200)]
        public IActionResult Authenticate(string UserName, string Password)
        {
            try
            {
                var user = _userBL.Authenticate(UserName, Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("forgotpassword")]
        [ProducesResponseType(typeof(GlobalResponseDTO), 200)]
        public IActionResult ForgotPassword(string UserName)
        {
            try
            {
                var user = _userBL.ForgotPassword(UserName);

                return Ok(user.Result);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("forgotusername")]
        [ProducesResponseType(typeof(GlobalResponseDTO), 200)]
        public IActionResult ForgotUsername(string Email)
        {
            try
            {
                var user = _userBL.ForgotUser(Email);

                return Ok(user.Result);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("reset")]
        [ProducesResponseType(typeof(GlobalResponseDTO), 200)]
        public async Task<IActionResult> ResetPassword(string guid, string password)
        {
            try
            {
                var user = await _userBL.ResetPassword(guid, password);

                return Ok(user);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("confirm")]
        [ProducesResponseType(typeof(GlobalResponseDTO), 200)]
        public async Task<IActionResult> ConfirmAccount(string guid)
        {
            try
            {
                var user = await _userBL.ConfirmRegistration(guid);

                return Ok(user);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("heartbeat")]
        public async Task<IActionResult> HeartBeat()
        {
            try
            {
                if (!String.IsNullOrEmpty(User.Identity.Name))
                {
                    var accesToken = Request.Headers["Authorization"];
                    string claimid = User.FindFirstValue(ClaimTypes.Name);
                    string roleid = User.FindFirstValue(ClaimTypes.Role);
                    bool Forged = await _userBL.ForgeryDetected(accesToken, Convert.ToInt32(claimid));
                    if (!Forged)
                    {
                        return Ok(_userBL.ReIssuetoken(claimid, roleid));
                    }
                    else
                    {
                        return BadRequest(new { message = "Invalid token" });
                    }


                }
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }



        }



        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        [Route("CreateUser")]
        [ProducesResponseType(typeof(GlobalResponseDTO), 200)]
        public async Task<IActionResult> CreateUser(UserCreationDTO userCreationDTO)
        {
            try
            {
                var user = await _userBL.CreateUser(userCreationDTO);

                return Ok(user);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }

        }
    }
}