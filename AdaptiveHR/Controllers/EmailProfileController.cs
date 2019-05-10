using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.emailprofile;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailProfileController : ControllerBase
    {
        private readonly IEmailProfileBL _EmailProfilebl;
        public EmailProfileController(IEmailProfileBL EmailProfileBL)
        {
            _EmailProfilebl = EmailProfileBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<EmailProfileDTO>), 200)]
        public async Task<IActionResult> GetEmailProfileList(PageRequest paging)
        {
            try
            {
                var data = await _EmailProfilebl.GetEmailProfileList(paging);

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("data")]
        [ProducesResponseType(typeof(EmailProfileDTO), 200)]
        public async Task<IActionResult> GetEmailProfileData(int ID)
        {
            try
            {
                var data = await _EmailProfilebl.GetEmailProfileData(ID);

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("remove")]
        [ProducesResponseType(typeof(GlobalResponseDTO), 200)]
        public async Task<IActionResult> DeleteEmailProfileData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _EmailProfilebl.DeleteEmailProfile(IDs);

                return Ok(data);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(typeof(GlobalResponseDTO), 200)]
        public async Task<IActionResult> SaveEmailProfileData(EmailProfileDTO model)
        {
            try
            {
                var data = await _EmailProfilebl.SaveEmailProfile(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}