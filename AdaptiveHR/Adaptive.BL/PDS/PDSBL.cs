using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.PDS
{
    public class PDSBL : IPDSBL
    {
        private AdaptiveHRContext _dbcontext;
        public PDSBL(AdaptiveHRContext adaptiveHRContext)
        {
            _dbcontext = adaptiveHRContext;
        }
        public Task<GlobalResponseDTO> DeletePDS()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PDSDTO>> GetPDSList()
        {
            try
            {
                var data = await _dbcontext.Pds.ToListAsync();
                var pdsdata = Mapper.Map<IEnumerable<Pds>, IEnumerable<PDSDTO> >(data);

                return pdsdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public Task<GlobalResponseDTO> SavePDS(PDSDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
