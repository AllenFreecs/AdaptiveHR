using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.emailtemplate;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTemplateController : ControllerBase
    {
        private readonly IEmailTemplateBL _EmailTemplatebl;
        public EmailTemplateController(IEmailTemplateBL EmailTemplateBL)
        {
            _EmailTemplatebl = EmailTemplateBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<EmailTemplateDTO>), 200)]
        public async Task<IActionResult> GetEmailTemplateList(PageRequest paging)
        {
            try
            {
                var data = await _EmailTemplatebl.GetEmailTemplateList(paging);

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
        [ProducesResponseType(typeof(EmailTemplateDTO), 200)]
        public async Task<IActionResult> GetEmailTemplateData(int ID)
        {
            try
            {
                var data = await _EmailTemplatebl.GetEmailTemplateData(ID);

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
        public async Task<IActionResult> DeleteEmailTemplateData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _EmailTemplatebl.DeleteEmailTemplate(IDs);

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
        [ProducesResponseType(typeof(EmailTemplateDTO), 200)]
        public async Task<IActionResult> SaveEmailTemplateData(EmailTemplateDTO model)
        {
            try
            {
                var data = await _EmailTemplatebl.SaveEmailTemplate(model);

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