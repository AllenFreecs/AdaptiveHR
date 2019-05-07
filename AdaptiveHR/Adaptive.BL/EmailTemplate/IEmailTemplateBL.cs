using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.emailtemplate
{
    public interface IEmailTemplateBL
    {
        Task<IEnumerable<EmailTemplateDTO>> GetEmailTemplateList(PageRequest paging);
        Task<EmailTemplateDTO> GetEmailTemplateData(int ID);
        Task<GlobalResponseDTO> SaveEmailTemplate(EmailTemplateDTO model);
        Task<GlobalResponseDTO> DeleteEmailTemplate(IEnumerable<int> IDs);
    }
}
