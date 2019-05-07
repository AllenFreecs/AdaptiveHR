using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.ot
{
    public interface IOTBL
    {
        Task<IEnumerable<OTDTO>> GetOTList(PageRequest paging);
        Task<OTDTO> GetOTData(int ID);
        Task<GlobalResponseDTO> SaveOT(OTDTO model);
        Task<GlobalResponseDTO> DeleteOT(IEnumerable<int> IDs);
    }
}
