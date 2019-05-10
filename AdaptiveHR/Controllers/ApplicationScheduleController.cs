using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.applicationschedule;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationScheduleController : ControllerBase
    {
        private readonly IApplicationScheduleBL _ApplicationSchedulebl;
        public ApplicationScheduleController(IApplicationScheduleBL ApplicationScheduleBL)
        {
            _ApplicationSchedulebl = ApplicationScheduleBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationScheduleDTO>), 200)]
        public async Task<IActionResult> GetApplicationScheduleList(PageRequest paging)
        {
            try
            {
                var data = await _ApplicationSchedulebl.GetApplicationScheduleList(paging);

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
        [ProducesResponseType(typeof(ApplicationScheduleDTO), 200)]
        public async Task<IActionResult> GetApplicationScheduleData(int ID)
        {
            try
            {
                var data = await _ApplicationSchedulebl.GetApplicationScheduleData(ID);

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
        public async Task<IActionResult> DeleteApplicationScheduleData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _ApplicationSchedulebl.DeleteApplicationSchedule(IDs);

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
        public async Task<IActionResult> SaveApplicationScheduleData(ApplicationScheduleDTO model)
        {
            try
            {
                var data = await _ApplicationSchedulebl.SaveApplicationSchedule(model);

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