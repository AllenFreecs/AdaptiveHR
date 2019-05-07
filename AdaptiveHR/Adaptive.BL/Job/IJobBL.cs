using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.job
{
    public interface IJobBL
    {
        Task<IEnumerable<JobDTO>> GetJobList(PageRequest paging);
        Task<JobDTO> GetJobData(int ID);
        Task<GlobalResponseDTO> SaveJob(JobDTO model);
        Task<GlobalResponseDTO> DeleteJob(IEnumerable<int> IDs);
    }
}
