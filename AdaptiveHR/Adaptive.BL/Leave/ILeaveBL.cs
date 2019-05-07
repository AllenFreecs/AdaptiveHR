using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.leave
{
    public interface ILeaveBL
    {
        Task<IEnumerable<LeaveDTO>> GetLeaveList(PageRequest paging);
        Task<LeaveDTO> GetLeaveData(int ID);
        Task<GlobalResponseDTO> SaveLeave(LeaveDTO model);
        Task<GlobalResponseDTO> DeleteLeave(IEnumerable<int> IDs);
    }
}
