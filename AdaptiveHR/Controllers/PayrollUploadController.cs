using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.payrollupload;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollUploadController : ControllerBase
    {
        private readonly IPayrollUploadBL _PayrollUploadbl;
        public PayrollUploadController(IPayrollUploadBL PayrollUploadBL)
        {
            _PayrollUploadbl = PayrollUploadBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<PayrollUploadDTO>), 200)]
        public async Task<IActionResult> GetPayrollUploadList(PageRequest paging)
        {
            try
            {
                var data = await _PayrollUploadbl.GetPayrollUploadList(paging);

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
        [ProducesResponseType(typeof(PayrollUploadDTO), 200)]
        public async Task<IActionResult> GetPayrollUploadData(int ID)
        {
            try
            {
                var data = await _PayrollUploadbl.GetPayrollUploadData(ID);

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
        public async Task<IActionResult> DeletePayrollUploadData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _PayrollUploadbl.DeletePayrollUpload(IDs);

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
        public async Task<IActionResult> SavePayrollUploadData(PayrollUploadDTO model)
        {
            try
            {
                var data = await _PayrollUploadbl.SavePayrollUpload(model);

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