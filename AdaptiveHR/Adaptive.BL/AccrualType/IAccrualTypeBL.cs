using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.accrualtype
{
    public interface IAccrualTypeBL
    {
        Task<IEnumerable<AccrualTypeDTO>> GetAccrualTypeList(PageRequest paging);
        Task<AccrualTypeDTO> GetAccrualTypeData(int ID);
        Task<GlobalResponseDTO> SaveAccrualType(AccrualTypeDTO model);
        Task<GlobalResponseDTO> DeleteAccrualType(IEnumerable<int> IDs);
    }
}
