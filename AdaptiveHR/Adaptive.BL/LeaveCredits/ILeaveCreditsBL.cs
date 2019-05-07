using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.leavecredits
{
    public interface ILeaveCreditsBL
    {
        Task<IEnumerable<LeaveCreditsDTO>> GetLeaveCreditsList(PageRequest paging);
        Task<LeaveCreditsDTO> GetLeaveCreditsData(int ID);
        Task<GlobalResponseDTO> SaveLeaveCredits(LeaveCreditsDTO model);
        Task<GlobalResponseDTO> DeleteLeaveCredits(IEnumerable<int> IDs);
    }
}
