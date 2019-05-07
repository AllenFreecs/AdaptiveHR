using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.approvergroupdetail
{
    public interface IApproverGroupDetailBL
    {
        Task<IEnumerable<ApproverGroupDetailDTO>> GetApproverGroupDetailList(PageRequest paging);
        Task<ApproverGroupDetailDTO> GetApproverGroupDetailData(int ID);
        Task<GlobalResponseDTO> SaveApproverGroupDetail(ApproverGroupDetailDTO model);
        Task<GlobalResponseDTO> DeleteApproverGroupDetail(IEnumerable<int> IDs);
    }
}
