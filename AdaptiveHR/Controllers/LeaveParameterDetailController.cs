using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.leaveparameterdetail;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveParameterDetailController : ControllerBase
    {
        private readonly ILeaveParameterDetailBL _LeaveParameterDetailbl;
        public LeaveParameterDetailController(ILeaveParameterDetailBL LeaveParameterDetailBL)
        {
            _LeaveParameterDetailbl = LeaveParameterDetailBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<LeaveParameterDetailDTO>), 200)]
        public async Task<IActionResult> GetLeaveParameterDetailList(PageRequest paging)
        {
            try
            {
                var data = await _LeaveParameterDetailbl.GetLeaveParameterDetailList(paging);

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
        [ProducesResponseType(typeof(LeaveParameterDetailDTO), 200)]
        public async Task<IActionResult> GetLeaveParameterDetailData(int ID)
        {
            try
            {
                var data = await _LeaveParameterDetailbl.GetLeaveParameterDetailData(ID);

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
        public async Task<IActionResult> DeleteLeaveParameterDetailData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _LeaveParameterDetailbl.DeleteLeaveParameterDetail(IDs);

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
        public async Task<IActionResult> SaveLeaveParameterDetailData(LeaveParameterDetailDTO model)
        {
            try
            {
                var data = await _LeaveParameterDetailbl.SaveLeaveParameterDetail(model);

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