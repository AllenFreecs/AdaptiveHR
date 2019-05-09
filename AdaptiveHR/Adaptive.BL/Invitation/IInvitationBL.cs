using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.invitation
{
    public interface IInvitationBL
    {
        Task<IEnumerable<InvitationDTO>> GetInvitationList(PageRequest paging);
        Task<InvitationDTO> GetInvitationData(int ID);
        Task<GlobalResponseDTO> SaveInvitation(InvitationDTO model);
        Task<GlobalResponseDTO> DeleteInvitation(IEnumerable<int> IDs);
    }
}
