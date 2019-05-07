using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.employee;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL _Employeebl;
        public EmployeeController(IEmployeeBL EmployeeBL)
        {
            _Employeebl = EmployeeBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDTO>), 200)]
        public async Task<IActionResult> GetEmployeeList(PageRequest paging)
        {
            try
            {
                var data = await _Employeebl.GetEmployeeList(paging);

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
        [ProducesResponseType(typeof(EmployeeDTO), 200)]
        public async Task<IActionResult> GetEmployeeData(int ID)
        {
            try
            {
                var data = await _Employeebl.GetEmployeeData(ID);

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
        public async Task<IActionResult> DeleteEmployeeData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _Employeebl.DeleteEmployee(IDs);

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
        [ProducesResponseType(typeof(EmployeeDTO), 200)]
        public async Task<IActionResult> SaveEmployeeData(EmployeeDTO model)
        {
            try
            {
                var data = await _Employeebl.SaveEmployee(model);

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