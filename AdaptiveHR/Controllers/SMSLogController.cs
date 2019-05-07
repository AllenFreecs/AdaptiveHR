using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.smslog;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSLogController : ControllerBase
    {
        private readonly ISMSLogBL _SMSLogbl;
        public SMSLogController(ISMSLogBL SMSLogBL)
        {
            _SMSLogbl = SMSLogBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<SMSLogDTO>), 200)]
        public async Task<IActionResult> GetSMSLogList(PageRequest paging)
        {
            try
            {
                var data = await _SMSLogbl.GetSMSLogList(paging);

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
        [ProducesResponseType(typeof(SMSLogDTO), 200)]
        public async Task<IActionResult> GetSMSLogData(int ID)
        {
            try
            {
                var data = await _SMSLogbl.GetSMSLogData(ID);

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
        public async Task<IActionResult> DeleteSMSLogData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _SMSLogbl.DeleteSMSLog(IDs);

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
        [ProducesResponseType(typeof(SMSLogDTO), 200)]
        public async Task<IActionResult> SaveSMSLogData(SMSLogDTO model)
        {
            try
            {
                var data = await _SMSLogbl.SaveSMSLog(model);

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