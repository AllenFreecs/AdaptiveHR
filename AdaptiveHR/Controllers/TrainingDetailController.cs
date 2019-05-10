using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveHR.Adaptive.BL.trainingdetail;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AdaptiveHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDetailController : ControllerBase
    {
        private readonly ITrainingDetailBL _TrainingDetailbl;
        public TrainingDetailController(ITrainingDetailBL TrainingDetailBL)
        {
            _TrainingDetailbl = TrainingDetailBL;
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<TrainingDetailDTO>), 200)]
        public async Task<IActionResult> GetTrainingDetailList(PageRequest paging)
        {
            try
            {
                var data = await _TrainingDetailbl.GetTrainingDetailList(paging);

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
        [ProducesResponseType(typeof(TrainingDetailDTO), 200)]
        public async Task<IActionResult> GetTrainingDetailData(int ID)
        {
            try
            {
                var data = await _TrainingDetailbl.GetTrainingDetailData(ID);

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
        public async Task<IActionResult> DeleteTrainingDetailData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _TrainingDetailbl.DeleteTrainingDetail(IDs);

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
        public async Task<IActionResult> SaveTrainingDetailData(TrainingDetailDTO model)
        {
            try
            {
                var data = await _TrainingDetailbl.SaveTrainingDetail(model);

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