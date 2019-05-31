using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.city
{
    public interface ICityBL
    {
        Task<IEnumerable<CityDTO>> GetCityList();
    }
}
