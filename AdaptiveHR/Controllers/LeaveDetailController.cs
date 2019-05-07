using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.leavedetail;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveDetailController : ControllerBase
    {
        private readonly ILeaveDetailBL _LeaveDetailbl;
        public LeaveDetailController(ILeaveDetailBL LeaveDetailBL)
        {
            _LeaveDetailbl = LeaveDetailBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<LeaveDetailDTO>), 200)]
        public async Task<IActionResult> GetLeaveDetailList(PageRequest paging)
        {
            try
            {
                var data = await _LeaveDetailbl.GetLeaveDetailList(paging);

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
        [ProducesResponseType(typeof(LeaveDetailDTO), 200)]
        public async Task<IActionResult> GetLeaveDetailData(int ID)
        {
            try
            {
                var data = await _LeaveDetailbl.GetLeaveDetailData(ID);

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
        public async Task<IActionResult> DeleteLeaveDetailData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _LeaveDetailbl.DeleteLeaveDetail(IDs);

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
        [ProducesResponseType(typeof(LeaveDetailDTO), 200)]
        public async Task<IActionResult> SaveLeaveDetailData(LeaveDetailDTO model)
        {
            try
            {
                var data = await _LeaveDetailbl.SaveLeaveDetail(model);

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