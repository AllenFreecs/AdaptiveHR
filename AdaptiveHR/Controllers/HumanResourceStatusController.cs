using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.humanresourcestatus;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanResourceStatusController : ControllerBase
    {
        private readonly IHumanResourceStatusBL _HumanResourceStatusbl;
        public HumanResourceStatusController(IHumanResourceStatusBL HumanResourceStatusBL)
        {
            _HumanResourceStatusbl = HumanResourceStatusBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<HumanResourceStatusDTO>), 200)]
        public async Task<IActionResult> GetHumanResourceStatusList(PageRequest paging)
        {
            try
            {
                var data = await _HumanResourceStatusbl.GetHumanResourceStatusList(paging);

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
        [ProducesResponseType(typeof(HumanResourceStatusDTO), 200)]
        public async Task<IActionResult> GetHumanResourceStatusData(int ID)
        {
            try
            {
                var data = await _HumanResourceStatusbl.GetHumanResourceStatusData(ID);

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
        public async Task<IActionResult> DeleteHumanResourceStatusData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _HumanResourceStatusbl.DeleteHumanResourceStatus(IDs);

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
        [ProducesResponseType(typeof(HumanResourceStatusDTO), 200)]
        public async Task<IActionResult> SaveHumanResourceStatusData(HumanResourceStatusDTO model)
        {
            try
            {
                var data = await _HumanResourceStatusbl.SaveHumanResourceStatus(model);

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