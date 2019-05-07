using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.humanresource
{
    public interface IHumanResourceBL
    {
        Task<IEnumerable<HumanResourceDTO>> GetHumanResourceList(PageRequest paging);
        Task<HumanResourceDTO> GetHumanResourceData(int ID);
        Task<GlobalResponseDTO> SaveHumanResource(HumanResourceDTO model);
        Task<GlobalResponseDTO> DeleteHumanResource(IEnumerable<int> IDs);
    }
}
