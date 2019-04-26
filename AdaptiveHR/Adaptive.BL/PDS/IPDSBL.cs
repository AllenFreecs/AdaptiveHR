using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.PDS
{
    public interface IPDSBL
    {
        Task<IEnumerable<PDSDTO>> GetPDSList();
        Task<GlobalResponseDTO> SavePDS(PDSDTO model);
        Task<GlobalResponseDTO> DeletePDS();


    }
}
