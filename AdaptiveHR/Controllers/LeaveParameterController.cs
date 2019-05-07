using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.leaveparameter;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveParameterController : ControllerBase
    {
        private readonly ILeaveParameterBL _LeaveParameterbl;
        public LeaveParameterController(ILeaveParameterBL LeaveParameterBL)
        {
            _LeaveParameterbl = LeaveParameterBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<LeaveParameterDTO>), 200)]
        public async Task<IActionResult> GetLeaveParameterList(PageRequest paging)
        {
            try
            {
                var data = await _LeaveParameterbl.GetLeaveParameterList(paging);

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
        [ProducesResponseType(typeof(LeaveParameterDTO), 200)]
        public async Task<IActionResult> GetLeaveParameterData(int ID)
        {
            try
            {
                var data = await _LeaveParameterbl.GetLeaveParameterData(ID);

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
        public async Task<IActionResult> DeleteLeaveParameterData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _LeaveParameterbl.DeleteLeaveParameter(IDs);

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
        [ProducesResponseType(typeof(LeaveParameterDTO), 200)]
        public async Task<IActionResult> SaveLeaveParameterData(LeaveParameterDTO model)
        {
            try
            {
                var data = await _LeaveParameterbl.SaveLeaveParameter(model);

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