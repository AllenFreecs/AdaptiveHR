using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.employee
{
    public class EmployeeBL : IEmployeeBL
    {
        private AdaptiveHRContext _dbcontext;
        public EmployeeBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteEmployee(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.Employee.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<EmployeeDTO> GetEmployeeData(int ID)
        {
            try
            {
                var data = await _dbcontext.Employee.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var Employeedata = Mapper.Map<Employee, EmployeeDTO>(data);

                return Employeedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeeList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.Employee.Where(c => c.IsActive == true).ToListAsync();
                var Employeedata = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(data);

                Employeedata = Employeedata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return Employeedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveEmployee(EmployeeDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<EmployeeDTO, Employee>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<EmployeeDTO, Employee>(model);
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
