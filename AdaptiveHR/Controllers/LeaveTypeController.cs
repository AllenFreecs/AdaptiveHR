using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.leavetype;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeBL _LeaveTypebl;
        public LeaveTypeController(ILeaveTypeBL LeaveTypeBL)
        {
            _LeaveTypebl = LeaveTypeBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<LeaveTypeDTO>), 200)]
        public async Task<IActionResult> GetLeaveTypeList(PageRequest paging)
        {
            try
            {
                var data = await _LeaveTypebl.GetLeaveTypeList(paging);

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
        [ProducesResponseType(typeof(LeaveTypeDTO), 200)]
        public async Task<IActionResult> GetLeaveTypeData(int ID)
        {
            try
            {
                var data = await _LeaveTypebl.GetLeaveTypeData(ID);

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
        public async Task<IActionResult> DeleteLeaveTypeData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _LeaveTypebl.DeleteLeaveType(IDs);

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
        [ProducesResponseType(typeof(LeaveTypeDTO), 200)]
        public async Task<IActionResult> SaveLeaveTypeData(LeaveTypeDTO model)
        {
            try
            {
                var data = await _LeaveTypebl.SaveLeaveType(model);

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