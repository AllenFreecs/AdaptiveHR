using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.accrualtype;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccrualTypeController : ControllerBase
    {
        private readonly IAccrualTypeBL _AccrualTypebl;
        public AccrualTypeController(IAccrualTypeBL AccrualTypeBL)
        {
            _AccrualTypebl = AccrualTypeBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<AccrualTypeDTO>), 200)]
        public async Task<IActionResult> GetAccrualTypeList(PageRequest paging)
        {
            try
            {
                var data = await _AccrualTypebl.GetAccrualTypeList(paging);

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
        [ProducesResponseType(typeof(AccrualTypeDTO), 200)]
        public async Task<IActionResult> GetAccrualTypeData(int ID)
        {
            try
            {
                var data = await _AccrualTypebl.GetAccrualTypeData(ID);

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
        public async Task<IActionResult> DeleteAccrualTypeData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _AccrualTypebl.DeleteAccrualType(IDs);

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
        public async Task<IActionResult> SaveAccrualTypeData(AccrualTypeDTO model)
        {
            try
            {
                var data = await _AccrualTypebl.SaveAccrualType(model);

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