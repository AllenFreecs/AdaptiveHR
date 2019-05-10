using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.smstemplate;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSTemplateController : ControllerBase
    {
        private readonly ISMSTemplateBL _SMSTemplatebl;
        public SMSTemplateController(ISMSTemplateBL SMSTemplateBL)
        {
            _SMSTemplatebl = SMSTemplateBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<SMSTemplateDTO>), 200)]
        public async Task<IActionResult> GetSMSTemplateList(PageRequest paging)
        {
            try
            {
                var data = await _SMSTemplatebl.GetSMSTemplateList(paging);

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
        [ProducesResponseType(typeof(SMSTemplateDTO), 200)]
        public async Task<IActionResult> GetSMSTemplateData(int ID)
        {
            try
            {
                var data = await _SMSTemplatebl.GetSMSTemplateData(ID);

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
        public async Task<IActionResult> DeleteSMSTemplateData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _SMSTemplatebl.DeleteSMSTemplate(IDs);

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
        public async Task<IActionResult> SaveSMSTemplateData(SMSTemplateDTO model)
        {
            try
            {
                var data = await _SMSTemplatebl.SaveSMSTemplate(model);

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