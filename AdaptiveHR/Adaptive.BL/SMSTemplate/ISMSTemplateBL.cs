using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.smstemplate
{
    public interface ISMSTemplateBL
    {
        Task<IEnumerable<SMSTemplateDTO>> GetSMSTemplateList(PageRequest paging);
        Task<SMSTemplateDTO> GetSMSTemplateData(int ID);
        Task<GlobalResponseDTO> SaveSMSTemplate(SMSTemplateDTO model);
        Task<GlobalResponseDTO> DeleteSMSTemplate(IEnumerable<int> IDs);
    }
}
