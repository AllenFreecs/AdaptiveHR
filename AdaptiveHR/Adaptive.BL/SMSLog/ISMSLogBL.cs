using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.smslog
{
    public interface ISMSLogBL
    {
        Task<IEnumerable<SMSLogDTO>> GetSMSLogList(PageRequest paging);
        Task<SMSLogDTO> GetSMSLogData(int ID);
        Task<GlobalResponseDTO> SaveSMSLog(SMSLogDTO model);
        Task<GlobalResponseDTO> DeleteSMSLog(IEnumerable<int> IDs);
    }
}
