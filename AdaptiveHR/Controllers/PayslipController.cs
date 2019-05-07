using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.payslip;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayslipController : ControllerBase
    {
        private readonly IPayslipBL _Payslipbl;
        public PayslipController(IPayslipBL PayslipBL)
        {
            _Payslipbl = PayslipBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<PayslipDTO>), 200)]
        public async Task<IActionResult> GetPayslipList(PageRequest paging)
        {
            try
            {
                var data = await _Payslipbl.GetPayslipList(paging);

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
        [ProducesResponseType(typeof(PayslipDTO), 200)]
        public async Task<IActionResult> GetPayslipData(int ID)
        {
            try
            {
                var data = await _Payslipbl.GetPayslipData(ID);

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
        public async Task<IActionResult> DeletePayslipData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _Payslipbl.DeletePayslip(IDs);

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
        [ProducesResponseType(typeof(PayslipDTO), 200)]
        public async Task<IActionResult> SavePayslipData(PayslipDTO model)
        {
            try
            {
                var data = await _Payslipbl.SavePayslip(model);

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