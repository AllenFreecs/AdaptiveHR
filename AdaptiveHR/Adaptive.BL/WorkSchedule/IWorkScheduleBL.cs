using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.workschedule
{
    public interface IWorkScheduleBL
    {
        Task<IEnumerable<WorkScheduleDTO>> GetWorkScheduleList(PageRequest paging);
        Task<WorkScheduleDTO> GetWorkScheduleData(int ID);
        Task<GlobalResponseDTO> SaveWorkSchedule(WorkScheduleDTO model);
        Task<GlobalResponseDTO> DeleteWorkSchedule(IEnumerable<int> IDs);
    }
}
