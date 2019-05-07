using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.approvergroupdetail
{
    public class ApproverGroupDetailBL : IApproverGroupDetailBL
    {
        private AdaptiveHRContext _dbcontext;
        public ApproverGroupDetailBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteApproverGroupDetail(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.ApproverGroupDetail.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<ApproverGroupDetailDTO> GetApproverGroupDetailData(int ID)
        {
            try
            {
                var data = await _dbcontext.ApproverGroupDetail.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var ApproverGroupDetaildata = Mapper.Map<ApproverGroupDetail, ApproverGroupDetailDTO>(data);

                return ApproverGroupDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<ApproverGroupDetailDTO>> GetApproverGroupDetailList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.ApproverGroupDetail.Where(c => c.IsActive == true).ToListAsync();
                var ApproverGroupDetaildata = Mapper.Map<IEnumerable<ApproverGroupDetail>, IEnumerable<ApproverGroupDetailDTO>>(data);

                ApproverGroupDetaildata = ApproverGroupDetaildata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return ApproverGroupDetaildata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveApproverGroupDetail(ApproverGroupDetailDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<ApproverGroupDetailDTO, ApproverGroupDetail>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<ApproverGroupDetailDTO, ApproverGroupDetail>(model);
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
