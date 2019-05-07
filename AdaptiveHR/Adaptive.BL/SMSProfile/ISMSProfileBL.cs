using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.smsprofile
{
    public interface ISMSProfileBL
    {
        Task<IEnumerable<SMSProfileDTO>> GetSMSProfileList(PageRequest paging);
        Task<SMSProfileDTO> GetSMSProfileData(int ID);
        Task<GlobalResponseDTO> SaveSMSProfile(SMSProfileDTO model);
        Task<GlobalResponseDTO> DeleteSMSProfile(IEnumerable<int> IDs);
    }
}
