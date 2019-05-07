using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.leavedetail
{
    public interface ILeaveDetailBL
    {
        Task<IEnumerable<LeaveDetailDTO>> GetLeaveDetailList(PageRequest paging);
        Task<LeaveDetailDTO> GetLeaveDetailData(int ID);
        Task<GlobalResponseDTO> SaveLeaveDetail(LeaveDetailDTO model);
        Task<GlobalResponseDTO> DeleteLeaveDetail(IEnumerable<int> IDs);
    }
}
