using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.applicationschedule
{
    public interface IApplicationScheduleBL
    {
        Task<IEnumerable<ApplicationScheduleDTO>> GetApplicationScheduleList(PageRequest paging);
        Task<ApplicationScheduleDTO> GetApplicationScheduleData(int ID);
        Task<GlobalResponseDTO> SaveApplicationSchedule(ApplicationScheduleDTO model);
        Task<GlobalResponseDTO> DeleteApplicationSchedule(IEnumerable<int> IDs);
    }
}
