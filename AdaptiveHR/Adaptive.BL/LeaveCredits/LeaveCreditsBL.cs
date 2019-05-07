using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.leavecredits
{
    public class LeaveCreditsBL : ILeaveCreditsBL
    {
        private AdaptiveHRContext _dbcontext;
        public LeaveCreditsBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteLeaveCredits(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.LeaveCredits.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<LeaveCreditsDTO> GetLeaveCreditsData(int ID)
        {
            try
            {
                var data = await _dbcontext.LeaveCredits.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var LeaveCreditsdata = Mapper.Map<LeaveCredits, LeaveCreditsDTO>(data);

                return LeaveCreditsdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<LeaveCreditsDTO>> GetLeaveCreditsList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.LeaveCredits.Where(c => c.IsActive == true).ToListAsync();
                var LeaveCreditsdata = Mapper.Map<IEnumerable<LeaveCredits>, IEnumerable<LeaveCreditsDTO>>(data);

                LeaveCreditsdata = LeaveCreditsdata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return LeaveCreditsdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveLeaveCredits(LeaveCreditsDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<LeaveCreditsDTO, LeaveCredits>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<LeaveCreditsDTO, LeaveCredits>(model);
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
