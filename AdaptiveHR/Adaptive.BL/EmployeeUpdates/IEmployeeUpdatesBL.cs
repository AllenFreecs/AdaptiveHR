using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.employeeupdates
{
    public interface IEmployeeUpdatesBL
    {
        Task<IEnumerable<EmployeeUpdatesDTO>> GetEmployeeUpdatesList(PageRequest paging);
        Task<EmployeeUpdatesDTO> GetEmployeeUpdatesData(int ID);
        Task<GlobalResponseDTO> SaveEmployeeUpdates(EmployeeUpdatesDTO model);
        Task<GlobalResponseDTO> DeleteEmployeeUpdates(IEnumerable<int> IDs);
    }
}
