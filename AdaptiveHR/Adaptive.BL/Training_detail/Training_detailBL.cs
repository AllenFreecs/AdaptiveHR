using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.trainingdetail
{
    public class TrainingDetailBL : ITrainingDetailBL
    {
        private AdaptiveHRContext _dbcontext;
        public TrainingDetailBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteTrainingDetail(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.TrainingDetail.Where(c => c.Id == item).SingleOrDefault();
                            data.IsActive = false;

                            _dbcontext.Entry(data).State = EntityState.Modified;
                            _dbcontext.SaveChanges();
                            transaction.Commit();

                        }
                        catch
                        {
                            transaction.Rollback();
                            return new GlobalResponseDTO() { IsSuccess = false, Message = "Server processes error" };
                            throw;
                        }
                    }
                }


                return new GlobalResponseDTO() { IsSuccess = true, Message = "Data has been deleted" };


            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<TrainingDetailDTO> GetTrainingDetailData(int ID)
        {
            try
            {
                var data = await _dbcontext.TrainingDetail.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var TrainingDetaildata = Mapper.Map<TrainingDetail, TrainingDetailDTO>(data);

                return TrainingDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<TrainingDetailDTO>> GetTrainingDetailList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.TrainingDetail.Where(c => c.IsActive == true).ToListAsync();
                var TrainingDetaildata = Mapper.Map<IEnumerable<TrainingDetail>, IEnumerable<TrainingDetailDTO>>(data);

                TrainingDetaildata = TrainingDetaildata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return TrainingDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveTrainingDetail(TrainingDetailDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<TrainingDetailDTO, TrainingDetail>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<TrainingDetailDTO, TrainingDetail>(model);
                            _dbcontext.Entry(data).State = EntityState.Added;
                        }
                        _dbcontext.SaveChanges();
                        transaction.Commit();

                    }
                    catch
                    {
                        transaction.Rollback();
                        return new GlobalResponseDTO() { IsSuccess = false, Message = "Server processes error" };
                        throw;
                    }
                }

                return new GlobalResponseDTO() { IsSuccess = true, Message = "Data has been saved." };
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }
    }
}
