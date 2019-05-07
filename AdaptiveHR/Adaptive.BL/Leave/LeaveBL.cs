using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.leave
{
    public class LeaveBL : ILeaveBL
    {
        private AdaptiveHRContext _dbcontext;
        public LeaveBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteLeave(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.Leave.Where(c => c.Id == item).SingleOrDefault();
                            data.IsActive = false;

                            _dbcontext.Entry(data).State = EntityState.Modified;
                            _dbcontext.SaveChanges();
                            transaction.Commit();

                        }
                        catch
                        {
                            transaction.Rollback();
                            return new GlobalResponseDTO() { IsSuccess = true, Message = "Server processes error" };
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

        public async Task<LeaveDTO> GetLeaveData(int ID)
        {
            try
            {
                var data = await _dbcontext.Leave.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var Leavedata = Mapper.Map<Leave, LeaveDTO>(data);

                return Leavedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<LeaveDTO>> GetLeaveList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.Leave.Where(c => c.IsActive == true).ToListAsync();
                var Leavedata = Mapper.Map<IEnumerable<Leave>, IEnumerable<LeaveDTO>>(data);

                Leavedata = Leavedata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return Leavedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveLeave(LeaveDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<LeaveDTO, Leave>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<LeaveDTO, Leave>(model);
                            _dbcontext.Entry(data).State = EntityState.Added;
                        }
                        _dbcontext.SaveChanges();
                        transaction.Commit();

                    }
                    catch
                    {
                        transaction.Rollback();
                        return new GlobalResponseDTO() { IsSuccess = true, Message = "Server processes error" };
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
