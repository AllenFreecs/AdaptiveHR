using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.seminar
{
    public interface ISeminarBL
    {
        Task<IEnumerable<SeminarDTO>> GetSeminarList(PageRequest paging);
        Task<SeminarDTO> GetSeminarData(int ID);
        Task<GlobalResponseDTO> SaveSeminar(SeminarDTO model);
        Task<GlobalResponseDTO> DeleteSeminar(IEnumerable<int> IDs);
    }
}
