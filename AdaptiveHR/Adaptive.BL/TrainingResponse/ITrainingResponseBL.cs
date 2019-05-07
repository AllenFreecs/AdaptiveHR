using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.trainingresponse
{
    public interface ITrainingResponseBL
    {
        Task<IEnumerable<TrainingResponseDTO>> GetTrainingResponseList(PageRequest paging);
        Task<TrainingResponseDTO> GetTrainingResponseData(int ID);
        Task<GlobalResponseDTO> SaveTrainingResponse(TrainingResponseDTO model);
        Task<GlobalResponseDTO> DeleteTrainingResponse(IEnumerable<int> IDs);
    }
}
