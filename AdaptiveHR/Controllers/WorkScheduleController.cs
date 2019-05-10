using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.workschedule;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkScheduleController : ControllerBase
    {
        private readonly IWorkScheduleBL _WorkSchedulebl;
        public WorkScheduleController(IWorkScheduleBL WorkScheduleBL)
        {
            _WorkSchedulebl = WorkScheduleBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<WorkScheduleDTO>), 200)]
        public async Task<IActionResult> GetWorkScheduleList(PageRequest paging)
        {
            try
            {
                var data = await _WorkSchedulebl.GetWorkScheduleList(paging);

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
        [ProducesResponseType(typeof(WorkScheduleDTO), 200)]
        public async Task<IActionResult> GetWorkScheduleData(int ID)
        {
            try
            {
                var data = await _WorkSchedulebl.GetWorkScheduleData(ID);

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
        public async Task<IActionResult> DeleteWorkScheduleData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _WorkSchedulebl.DeleteWorkSchedule(IDs);

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
        public async Task<IActionResult> SaveWorkScheduleData(WorkScheduleDTO model)
        {
            try
            {
                var data = await _WorkSchedulebl.SaveWorkSchedule(model);

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