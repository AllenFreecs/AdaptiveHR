using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.seminar;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        private readonly ISeminarBL _Seminarbl;
        public SeminarController(ISeminarBL SeminarBL)
        {
            _Seminarbl = SeminarBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<SeminarDTO>), 200)]
        public async Task<IActionResult> GetSeminarList(PageRequest paging)
        {
            try
            {
                var data = await _Seminarbl.GetSeminarList(paging);

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
        [ProducesResponseType(typeof(SeminarDTO), 200)]
        public async Task<IActionResult> GetSeminarData(int ID)
        {
            try
            {
                var data = await _Seminarbl.GetSeminarData(ID);

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
        public async Task<IActionResult> DeleteSeminarData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _Seminarbl.DeleteSeminar(IDs);

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
        [ProducesResponseType(typeof(SeminarDTO), 200)]
        public async Task<IActionResult> SaveSeminarData(SeminarDTO model)
        {
            try
            {
                var data = await _Seminarbl.SaveSeminar(model);

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