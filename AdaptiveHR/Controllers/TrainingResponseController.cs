using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.trainingresponse;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingResponseController : ControllerBase
    {
        private readonly ITrainingResponseBL _TrainingResponsebl;
        public TrainingResponseController(ITrainingResponseBL TrainingResponseBL)
        {
            _TrainingResponsebl = TrainingResponseBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<TrainingResponseDTO>), 200)]
        public async Task<IActionResult> GetTrainingResponseList(PageRequest paging)
        {
            try
            {
                var data = await _TrainingResponsebl.GetTrainingResponseList(paging);

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
        [ProducesResponseType(typeof(TrainingResponseDTO), 200)]
        public async Task<IActionResult> GetTrainingResponseData(int ID)
        {
            try
            {
                var data = await _TrainingResponsebl.GetTrainingResponseData(ID);

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
        public async Task<IActionResult> DeleteTrainingResponseData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _TrainingResponsebl.DeleteTrainingResponse(IDs);

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
        [ProducesResponseType(typeof(TrainingResponseDTO), 200)]
        public async Task<IActionResult> SaveTrainingResponseData(TrainingResponseDTO model)
        {
            try
            {
                var data = await _TrainingResponsebl.SaveTrainingResponse(model);

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