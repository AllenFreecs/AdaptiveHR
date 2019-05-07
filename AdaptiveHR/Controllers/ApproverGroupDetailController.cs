using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.approvergroupdetail;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproverGroupDetailController : ControllerBase
    {
        private readonly IApproverGroupDetailBL _ApproverGroupDetailbl;
        public ApproverGroupDetailController(IApproverGroupDetailBL ApproverGroupDetailBL)
        {
            _ApproverGroupDetailbl = ApproverGroupDetailBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<ApproverGroupDetailDTO>), 200)]
        public async Task<IActionResult> GetApproverGroupDetailList(PageRequest paging)
        {
            try
            {
                var data = await _ApproverGroupDetailbl.GetApproverGroupDetailList(paging);

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
        [ProducesResponseType(typeof(ApproverGroupDetailDTO), 200)]
        public async Task<IActionResult> GetApproverGroupDetailData(int ID)
        {
            try
            {
                var data = await _ApproverGroupDetailbl.GetApproverGroupDetailData(ID);

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
        public async Task<IActionResult> DeleteApproverGroupDetailData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _ApproverGroupDetailbl.DeleteApproverGroupDetail(IDs);

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
        [ProducesResponseType(typeof(ApproverGroupDetailDTO), 200)]
        public async Task<IActionResult> SaveApproverGroupDetailData(ApproverGroupDetailDTO model)
        {
            try
            {
                var data = await _ApproverGroupDetailbl.SaveApproverGroupDetail(model);

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