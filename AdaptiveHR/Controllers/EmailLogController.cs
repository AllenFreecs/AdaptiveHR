using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.emaillog;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailLogController : ControllerBase
    {
        private readonly IEmailLogBL _EmailLogbl;
        public EmailLogController(IEmailLogBL EmailLogBL)
        {
            _EmailLogbl = EmailLogBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<EmailLogDTO>), 200)]
        public async Task<IActionResult> GetEmailLogList(PageRequest paging)
        {
            try
            {
                var data = await _EmailLogbl.GetEmailLogList(paging);

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
        [ProducesResponseType(typeof(EmailLogDTO), 200)]
        public async Task<IActionResult> GetEmailLogData(int ID)
        {
            try
            {
                var data = await _EmailLogbl.GetEmailLogData(ID);

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
        public async Task<IActionResult> DeleteEmailLogData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _EmailLogbl.DeleteEmailLog(IDs);

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
        public async Task<IActionResult> SaveEmailLogData(EmailLogDTO model)
        {
            try
            {
                var data = await _EmailLogbl.SaveEmailLog(model);

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