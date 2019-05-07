using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.status
{
    public interface IStatusBL
    {
        Task<IEnumerable<StatusDTO>> GetStatusList(PageRequest paging);
        Task<StatusDTO> GetStatusData(int ID);
        Task<GlobalResponseDTO> SaveStatus(StatusDTO model);
        Task<GlobalResponseDTO> DeleteStatus(IEnumerable<int> IDs);
    }
}
