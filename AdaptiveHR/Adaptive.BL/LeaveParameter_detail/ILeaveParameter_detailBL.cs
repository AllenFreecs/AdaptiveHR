using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.leaveparameterdetail
{
    public interface ILeaveParameterDetailBL
    {
        Task<IEnumerable<LeaveParameterDetailDTO>> GetLeaveParameterDetailList(PageRequest paging);
        Task<LeaveParameterDetailDTO> GetLeaveParameterDetailData(int ID);
        Task<GlobalResponseDTO> SaveLeaveParameterDetail(LeaveParameterDetailDTO model);
        Task<GlobalResponseDTO> DeleteLeaveParameterDetail(IEnumerable<int> IDs);
    }
}
