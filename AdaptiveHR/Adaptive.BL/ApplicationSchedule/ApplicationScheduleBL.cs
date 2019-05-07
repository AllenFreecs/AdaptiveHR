using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.applicationschedule
{
    public class ApplicationScheduleBL : IApplicationScheduleBL
    {
        private AdaptiveHRContext _dbcontext;
        public ApplicationScheduleBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteApplicationSchedule(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.ApplicationSchedule.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<ApplicationScheduleDTO> GetApplicationScheduleData(int ID)
        {
            try
            {
                var data = await _dbcontext.ApplicationSchedule.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var ApplicationScheduledata = Mapper.Map<ApplicationSchedule, ApplicationScheduleDTO>(data);

                return ApplicationScheduledata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<ApplicationScheduleDTO>> GetApplicationScheduleList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.ApplicationSchedule.Where(c => c.IsActive == true).ToListAsync();
                var ApplicationScheduledata = Mapper.Map<IEnumerable<ApplicationSchedule>, IEnumerable<ApplicationScheduleDTO>>(data);

                ApplicationScheduledata = ApplicationScheduledata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return ApplicationScheduledata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveApplicationSchedule(ApplicationScheduleDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<ApplicationScheduleDTO, ApplicationSchedule>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<ApplicationScheduleDTO, ApplicationSchedule>(model);
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
