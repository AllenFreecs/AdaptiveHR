using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.payslip
{
    public interface IPayslipBL
    {
        Task<IEnumerable<PayslipDTO>> GetPayslipList(PageRequest paging);
        Task<PayslipDTO> GetPayslipData(int ID);
        Task<GlobalResponseDTO> SavePayslip(PayslipDTO model);
        Task<GlobalResponseDTO> DeletePayslip(IEnumerable<int> IDs);
    }
}
