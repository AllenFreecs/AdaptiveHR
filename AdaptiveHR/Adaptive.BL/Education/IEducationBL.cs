using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.education
{
    public interface IEducationBL
    {
        Task<IEnumerable<EducationDTO>> GetEducationList(PageRequest paging);
        Task<EducationDTO> GetEducationData(int ID);
        Task<GlobalResponseDTO> SaveEducation(EducationDTO model);
        Task<GlobalResponseDTO> DeleteEducation(IEnumerable<int> IDs);
    }
}
