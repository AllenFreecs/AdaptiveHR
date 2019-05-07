using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.leaveparameter
{
    public interface ILeaveParameterBL
    {
        Task<IEnumerable<LeaveParameterDTO>> GetLeaveParameterList(PageRequest paging);
        Task<LeaveParameterDTO> GetLeaveParameterData(int ID);
        Task<GlobalResponseDTO> SaveLeaveParameter(LeaveParameterDTO model);
        Task<GlobalResponseDTO> DeleteLeaveParameter(IEnumerable<int> IDs);
    }
}
