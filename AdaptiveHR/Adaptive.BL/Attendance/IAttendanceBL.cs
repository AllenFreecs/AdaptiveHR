using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.attendance
{
    public interface IAttendanceBL
    {
        Task<IEnumerable<AttendanceDTO>> GetAttendanceList(PageRequest paging);
        Task<AttendanceDTO> GetAttendanceData(int ID);
        Task<GlobalResponseDTO> SaveAttendance(AttendanceDTO model);
        Task<GlobalResponseDTO> DeleteAttendance(IEnumerable<int> IDs);
    }
}
