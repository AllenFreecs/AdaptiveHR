﻿using System;
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

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<PDSDTO>), 200)]
        public async Task<IActionResult> GetPDSList(PageRequest paging)
        {
            try
            {
                var data = await _pdsbl.GetPDSList(paging);

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
        [ProducesResponseType(typeof(PDSDTO), 200)]
        public async Task<IActionResult> GetPDSData(int ID)
        {
            try
            {
                var data = await _pdsbl.GetPDSData(ID);

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
        public async Task<IActionResult> DeletePDSData(IEnumerable<int> IDs)
        {
            try
            {
                var data = await _pdsbl.DeletePDS(IDs);

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
        [ProducesResponseType(typeof(PDSDTO), 200)]
        public async Task<IActionResult> SavePDSData(PDSDTO model)
        {
            try
            {
                var data = await _pdsbl.SavePDS(model);

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