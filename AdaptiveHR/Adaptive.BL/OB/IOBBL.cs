using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.ob
{
    public interface IOBBL
    {
        Task<IEnumerable<OBDTO>> GetOBList(PageRequest paging);
        Task<OBDTO> GetOBData(int ID);
        Task<GlobalResponseDTO> SaveOB(OBDTO model);
        Task<GlobalResponseDTO> DeleteOB(IEnumerable<int> IDs);
    }
}
