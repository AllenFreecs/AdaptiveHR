using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.humanresource;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanResourceController : ControllerBase
    {
        private readonly IHumanResourceBL _HumanResourcebl;
        public HumanResourceController(IHumanResourceBL HumanResourceBL)
        {
            _HumanResourcebl = HumanResourceBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<HumanResourceDTO>), 200)]
        public async Task<IActionResult> GetHumanResourceList(PageRequest paging)
        {
            try
            {
                var data = await _HumanResourcebl.GetHumanResourceList(paging);

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
        [ProducesResponseType(typeof(HumanResourceDTO), 200)]
        public async Task<IActionResult> GetHumanResourceData(int ID)
        {
            try
            {
                var data = await _HumanResourcebl.GetHumanResourceData(ID);

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
        public async Task<IActionResult> DeleteHumanResourceData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _HumanResourcebl.DeleteHumanResource(IDs);

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
        [ProducesResponseType(typeof(HumanResourceDTO), 200)]
        public async Task<IActionResult> SaveHumanResourceData(HumanResourceDTO model)
        {
            try
            {
                var data = await _HumanResourcebl.SaveHumanResource(model);

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