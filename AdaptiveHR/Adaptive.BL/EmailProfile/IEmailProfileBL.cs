using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.emailprofile
{
    public interface IEmailProfileBL
    {
        Task<IEnumerable<EmailProfileDTO>> GetEmailProfileList(PageRequest paging);
        Task<EmailProfileDTO> GetEmailProfileData(int ID);
        Task<GlobalResponseDTO> SaveEmailProfile(EmailProfileDTO model);
        Task<GlobalResponseDTO> DeleteEmailProfile(IEnumerable<int> IDs);
    }
}
