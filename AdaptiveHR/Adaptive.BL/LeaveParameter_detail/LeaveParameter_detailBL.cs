using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.leaveparameterdetail
{
    public class LeaveParameterDetailBL : ILeaveParameterDetailBL
    {
        private AdaptiveHRContext _dbcontext;
        public LeaveParameterDetailBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteLeaveParameterDetail(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.LeaveParameterDetail.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<LeaveParameterDetailDTO> GetLeaveParameterDetailData(int ID)
        {
            try
            {
                var data = await _dbcontext.LeaveParameterDetail.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var LeaveParameterDetaildata = Mapper.Map<LeaveParameterDetail, LeaveParameterDetailDTO>(data);

                return LeaveParameterDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<LeaveParameterDetailDTO>> GetLeaveParameterDetailList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.LeaveParameterDetail.Where(c => c.IsActive == true).ToListAsync();
                var LeaveParameterDetaildata = Mapper.Map<IEnumerable<LeaveParameterDetail>, IEnumerable<LeaveParameterDetailDTO>>(data);

                LeaveParameterDetaildata = LeaveParameterDetaildata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return LeaveParameterDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveLeaveParameterDetail(LeaveParameterDetailDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<LeaveParameterDetailDTO, LeaveParameterDetail>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<LeaveParameterDetailDTO, LeaveParameterDetail>(model);
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
