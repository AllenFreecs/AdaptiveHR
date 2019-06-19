using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.pds
{
    public interface IPDSBL
    {
        Task<IEnumerable<PDSDTO>> GetPDSList(PageRequest paging);
        Task<PDSDTO> GetPDSData(int ID);
        Task<GlobalResponseDTO> SavePDS(PDSDTO model);
        Task<GlobalResponseDTO> DeletePDS(IEnumerable<int> IDs);
    }
}
