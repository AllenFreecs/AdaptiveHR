using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.emaillog
{
    public interface IEmailLogBL
    {
        Task<IEnumerable<EmailLogDTO>> GetEmailLogList(PageRequest paging);
        Task<EmailLogDTO> GetEmailLogData(int ID);
        Task<GlobalResponseDTO> SaveEmailLog(EmailLogDTO model);
        Task<GlobalResponseDTO> DeleteEmailLog(IEnumerable<int> IDs);
    }
}
