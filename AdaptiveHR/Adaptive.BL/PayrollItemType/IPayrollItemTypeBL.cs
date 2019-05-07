using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.payrollitemtype
{
    public interface IPayrollItemTypeBL
    {
        Task<IEnumerable<PayrollItemTypeDTO>> GetPayrollItemTypeList(PageRequest paging);
        Task<PayrollItemTypeDTO> GetPayrollItemTypeData(int ID);
        Task<GlobalResponseDTO> SavePayrollItemType(PayrollItemTypeDTO model);
        Task<GlobalResponseDTO> DeletePayrollItemType(IEnumerable<int> IDs);
    }
}
