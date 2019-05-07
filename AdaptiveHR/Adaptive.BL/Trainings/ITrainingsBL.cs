using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.trainings
{
    public interface ITrainingsBL
    {
        Task<IEnumerable<TrainingsDTO>> GetTrainingsList(PageRequest paging);
        Task<TrainingsDTO> GetTrainingsData(int ID);
        Task<GlobalResponseDTO> SaveTrainings(TrainingsDTO model);
        Task<GlobalResponseDTO> DeleteTrainings(IEnumerable<int> IDs);
    }
}
