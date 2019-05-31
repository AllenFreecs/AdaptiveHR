using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.city
{
    public class CityBL : ICityBL
    {
        private AdaptiveHRContext _dbcontext;
        public CityBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

       
        public async Task<IEnumerable<CityDTO>> GetCityList()
        {
            try
            {
                var data = await _dbcontext.City.Where(c => c.IsActive == true).ToListAsync();
                var Citydata = Mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(data);

                return Citydata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }
    }
}
