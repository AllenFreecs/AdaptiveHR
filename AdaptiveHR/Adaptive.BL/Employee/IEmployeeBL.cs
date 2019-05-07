using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.employee
{
    public interface IEmployeeBL
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeeList(PageRequest paging);
        Task<EmployeeDTO> GetEmployeeData(int ID);
        Task<GlobalResponseDTO> SaveEmployee(EmployeeDTO model);
        Task<GlobalResponseDTO> DeleteEmployee(IEnumerable<int> IDs);
    }
}
