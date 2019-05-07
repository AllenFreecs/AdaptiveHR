using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.leavetype
{
    public interface ILeaveTypeBL
    {
        Task<IEnumerable<LeaveTypeDTO>> GetLeaveTypeList(PageRequest paging);
        Task<LeaveTypeDTO> GetLeaveTypeData(int ID);
        Task<GlobalResponseDTO> SaveLeaveType(LeaveTypeDTO model);
        Task<GlobalResponseDTO> DeleteLeaveType(IEnumerable<int> IDs);
    }
}
