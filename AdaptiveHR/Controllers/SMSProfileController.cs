using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.smsprofile;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSProfileController : ControllerBase
    {
        private readonly ISMSProfileBL _SMSProfilebl;
        public SMSProfileController(ISMSProfileBL SMSProfileBL)
        {
            _SMSProfilebl = SMSProfileBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<SMSProfileDTO>), 200)]
        public async Task<IActionResult> GetSMSProfileList(PageRequest paging)
        {
            try
            {
                var data = await _SMSProfilebl.GetSMSProfileList(paging);

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
        [ProducesResponseType(typeof(SMSProfileDTO), 200)]
        public async Task<IActionResult> GetSMSProfileData(int ID)
        {
            try
            {
                var data = await _SMSProfilebl.GetSMSProfileData(ID);

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
        public async Task<IActionResult> DeleteSMSProfileData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _SMSProfilebl.DeleteSMSProfile(IDs);

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
        public async Task<IActionResult> SaveSMSProfileData(SMSProfileDTO model)
        {
            try
            {
                var data = await _SMSProfilebl.SaveSMSProfile(model);

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