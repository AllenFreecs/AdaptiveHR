using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.leavedetail
{
    public class LeaveDetailBL : ILeaveDetailBL
    {
        private AdaptiveHRContext _dbcontext;
        public LeaveDetailBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteLeaveDetail(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.LeaveDetail.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<LeaveDetailDTO> GetLeaveDetailData(int ID)
        {
            try
            {
                var data = await _dbcontext.LeaveDetail.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var LeaveDetaildata = Mapper.Map<LeaveDetail, LeaveDetailDTO>(data);

                return LeaveDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<LeaveDetailDTO>> GetLeaveDetailList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.LeaveDetail.Where(c => c.IsActive == true).ToListAsync();
                var LeaveDetaildata = Mapper.Map<IEnumerable<LeaveDetail>, IEnumerable<LeaveDetailDTO>>(data);

                LeaveDetaildata = LeaveDetaildata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return LeaveDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveLeaveDetail(LeaveDetailDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<LeaveDetailDTO, LeaveDetail>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<LeaveDetailDTO, LeaveDetail>(model);
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
