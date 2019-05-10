using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.leavecredits;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveCreditsController : ControllerBase
    {
        private readonly ILeaveCreditsBL _LeaveCreditsbl;
        public LeaveCreditsController(ILeaveCreditsBL LeaveCreditsBL)
        {
            _LeaveCreditsbl = LeaveCreditsBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<LeaveCreditsDTO>), 200)]
        public async Task<IActionResult> GetLeaveCreditsList(PageRequest paging)
        {
            try
            {
                var data = await _LeaveCreditsbl.GetLeaveCreditsList(paging);

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
        [ProducesResponseType(typeof(LeaveCreditsDTO), 200)]
        public async Task<IActionResult> GetLeaveCreditsData(int ID)
        {
            try
            {
                var data = await _LeaveCreditsbl.GetLeaveCreditsData(ID);

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
        public async Task<IActionResult> DeleteLeaveCreditsData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _LeaveCreditsbl.DeleteLeaveCredits(IDs);

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
        public async Task<IActionResult> SaveLeaveCreditsData(LeaveCreditsDTO model)
        {
            try
            {
                var data = await _LeaveCreditsbl.SaveLeaveCredits(model);

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