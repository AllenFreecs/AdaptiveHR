using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.approvergroup;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproverGroupController : ControllerBase
    {
        private readonly IApproverGroupBL _ApproverGroupbl;
        public ApproverGroupController(IApproverGroupBL ApproverGroupBL)
        {
            _ApproverGroupbl = ApproverGroupBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<ApproverGroupDTO>), 200)]
        public async Task<IActionResult> GetApproverGroupList(PageRequest paging)
        {
            try
            {
                var data = await _ApproverGroupbl.GetApproverGroupList(paging);

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
        [ProducesResponseType(typeof(ApproverGroupDTO), 200)]
        public async Task<IActionResult> GetApproverGroupData(int ID)
        {
            try
            {
                var data = await _ApproverGroupbl.GetApproverGroupData(ID);

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
        public async Task<IActionResult> DeleteApproverGroupData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _ApproverGroupbl.DeleteApproverGroup(IDs);

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
        public async Task<IActionResult> SaveApproverGroupData(ApproverGroupDTO model)
        {
            try
            {
                var data = await _ApproverGroupbl.SaveApproverGroup(model);

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