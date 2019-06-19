using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.city
{
    public interface ICityBL
    {
        Task<IEnumerable<CityDTO>> GetCityList(PageRequest paging);
        Task<CityDTO> GetCityData(int ID);
        Task<GlobalResponseDTO> SaveCity(CityDTO model);
        Task<GlobalResponseDTO> DeleteCity(IEnumerable<int> IDs);
    }
}
