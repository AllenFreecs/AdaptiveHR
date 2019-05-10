using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.employeeupdates;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeUpdatesController : ControllerBase
    {
        private readonly IEmployeeUpdatesBL _EmployeeUpdatesbl;
        public EmployeeUpdatesController(IEmployeeUpdatesBL EmployeeUpdatesBL)
        {
            _EmployeeUpdatesbl = EmployeeUpdatesBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeUpdatesDTO>), 200)]
        public async Task<IActionResult> GetEmployeeUpdatesList(PageRequest paging)
        {
            try
            {
                var data = await _EmployeeUpdatesbl.GetEmployeeUpdatesList(paging);

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
        [ProducesResponseType(typeof(EmployeeUpdatesDTO), 200)]
        public async Task<IActionResult> GetEmployeeUpdatesData(int ID)
        {
            try
            {
                var data = await _EmployeeUpdatesbl.GetEmployeeUpdatesData(ID);

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
        public async Task<IActionResult> DeleteEmployeeUpdatesData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _EmployeeUpdatesbl.DeleteEmployeeUpdates(IDs);

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
        public async Task<IActionResult> SaveEmployeeUpdatesData(EmployeeUpdatesDTO model)
        {
            try
            {
                var data = await _EmployeeUpdatesbl.SaveEmployeeUpdates(model);

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