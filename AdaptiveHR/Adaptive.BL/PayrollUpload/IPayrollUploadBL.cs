using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.payrollupload
{
    public interface IPayrollUploadBL
    {
        Task<IEnumerable<PayrollUploadDTO>> GetPayrollUploadList(PageRequest paging);
        Task<PayrollUploadDTO> GetPayrollUploadData(int ID);
        Task<GlobalResponseDTO> SavePayrollUpload(PayrollUploadDTO model);
        Task<GlobalResponseDTO> DeletePayrollUpload(IEnumerable<int> IDs);
    }
}
