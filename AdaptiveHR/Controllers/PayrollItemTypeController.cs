using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.payrollitemtype;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollItemTypeController : ControllerBase
    {
        private readonly IPayrollItemTypeBL _PayrollItemTypebl;
        public PayrollItemTypeController(IPayrollItemTypeBL PayrollItemTypeBL)
        {
            _PayrollItemTypebl = PayrollItemTypeBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<PayrollItemTypeDTO>), 200)]
        public async Task<IActionResult> GetPayrollItemTypeList(PageRequest paging)
        {
            try
            {
                var data = await _PayrollItemTypebl.GetPayrollItemTypeList(paging);

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
        [ProducesResponseType(typeof(PayrollItemTypeDTO), 200)]
        public async Task<IActionResult> GetPayrollItemTypeData(int ID)
        {
            try
            {
                var data = await _PayrollItemTypebl.GetPayrollItemTypeData(ID);

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
        public async Task<IActionResult> DeletePayrollItemTypeData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _PayrollItemTypebl.DeletePayrollItemType(IDs);

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
        public async Task<IActionResult> SavePayrollItemTypeData(PayrollItemTypeDTO model)
        {
            try
            {
                var data = await _PayrollItemTypebl.SavePayrollItemType(model);

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