using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.approvergroup
{
    public interface IApproverGroupBL
    {
        Task<IEnumerable<ApproverGroupDTO>> GetApproverGroupList(PageRequest paging);
        Task<ApproverGroupDTO> GetApproverGroupData(int ID);
        Task<GlobalResponseDTO> SaveApproverGroup(ApproverGroupDTO model);
        Task<GlobalResponseDTO> DeleteApproverGroup(IEnumerable<int> IDs);
    }
}
