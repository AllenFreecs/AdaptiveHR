using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.PDS;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDSController : ControllerBase
    {
        private readonly IPDSBL _pdsbl;
        public PDSController(IPDSBL PDSBL)
        {
            _pdsbl = PDSBL;
        }
        //public PDSController()
        //{

        //}
        //[HttpGet]
        //[Route("test")]
        //[ProducesResponseType(typeof(string), 200)]
        //public async Task<IActionResult> GetPDSList()
        //{
        //    try
        //    {


        //        return Ok("testing");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.GetCurrentClassLogger().Error(ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<PDSDTO>), 200)]
        public async Task<IActionResult> GetPDSList()
        {
            try
            {
                var data = await _pdsbl.GetPDSList();

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
    }
}