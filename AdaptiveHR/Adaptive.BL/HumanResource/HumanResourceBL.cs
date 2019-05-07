using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.humanresource
{
    public class HumanResourceBL : IHumanResourceBL
    {
        private AdaptiveHRContext _dbcontext;
        public HumanResourceBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteHumanResource(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.HumanResource.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<HumanResourceDTO> GetHumanResourceData(int ID)
        {
            try
            {
                var data = await _dbcontext.HumanResource.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var HumanResourcedata = Mapper.Map<HumanResource, HumanResourceDTO>(data);

                return HumanResourcedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<HumanResourceDTO>> GetHumanResourceList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.HumanResource.Where(c => c.IsActive == true).ToListAsync();
                var HumanResourcedata = Mapper.Map<IEnumerable<HumanResource>, IEnumerable<HumanResourceDTO>>(data);

                HumanResourcedata = HumanResourcedata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return HumanResourcedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveHumanResource(HumanResourceDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<HumanResourceDTO, HumanResource>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<HumanResourceDTO, HumanResource>(model);
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
