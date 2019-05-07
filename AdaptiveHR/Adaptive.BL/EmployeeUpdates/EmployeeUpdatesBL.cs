using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.employeeupdates
{
    public class EmployeeUpdatesBL : IEmployeeUpdatesBL
    {
        private AdaptiveHRContext _dbcontext;
        public EmployeeUpdatesBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteEmployeeUpdates(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.EmployeeUpdates.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<EmployeeUpdatesDTO> GetEmployeeUpdatesData(int ID)
        {
            try
            {
                var data = await _dbcontext.EmployeeUpdates.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var EmployeeUpdatesdata = Mapper.Map<EmployeeUpdates, EmployeeUpdatesDTO>(data);

                return EmployeeUpdatesdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<EmployeeUpdatesDTO>> GetEmployeeUpdatesList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.EmployeeUpdates.Where(c => c.IsActive == true).ToListAsync();
                var EmployeeUpdatesdata = Mapper.Map<IEnumerable<EmployeeUpdates>, IEnumerable<EmployeeUpdatesDTO>>(data);

                EmployeeUpdatesdata = EmployeeUpdatesdata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return EmployeeUpdatesdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveEmployeeUpdates(EmployeeUpdatesDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<EmployeeUpdatesDTO, EmployeeUpdates>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<EmployeeUpdatesDTO, EmployeeUpdates>(model);
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
