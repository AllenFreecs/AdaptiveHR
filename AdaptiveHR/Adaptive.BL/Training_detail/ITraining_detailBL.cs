using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.trainingdetail
{
    public interface ITrainingDetailBL
    {
        Task<IEnumerable<TrainingDetailDTO>> GetTrainingDetailList(PageRequest paging);
        Task<TrainingDetailDTO> GetTrainingDetailData(int ID);
        Task<GlobalResponseDTO> SaveTrainingDetail(TrainingDetailDTO model);
        Task<GlobalResponseDTO> DeleteTrainingDetail(IEnumerable<int> IDs);
    }
}
