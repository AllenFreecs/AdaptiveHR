using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.humanresourcestatus
{
    public interface IHumanResourceStatusBL
    {
        Task<IEnumerable<HumanResourceStatusDTO>> GetHumanResourceStatusList(PageRequest paging);
        Task<HumanResourceStatusDTO> GetHumanResourceStatusData(int ID);
        Task<GlobalResponseDTO> SaveHumanResourceStatus(HumanResourceStatusDTO model);
        Task<GlobalResponseDTO> DeleteHumanResourceStatus(IEnumerable<int> IDs);
    }
}
