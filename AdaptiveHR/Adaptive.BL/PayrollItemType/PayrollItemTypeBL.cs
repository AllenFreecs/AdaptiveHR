using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.payrollitemtype
{
    public class PayrollItemTypeBL : IPayrollItemTypeBL
    {
        private AdaptiveHRContext _dbcontext;
        public PayrollItemTypeBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeletePayrollItemType(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.PayrollItemType.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<PayrollItemTypeDTO> GetPayrollItemTypeData(int ID)
        {
            try
            {
                var data = await _dbcontext.PayrollItemType.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var PayrollItemTypedata = Mapper.Map<PayrollItemType, PayrollItemTypeDTO>(data);

                return PayrollItemTypedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<PayrollItemTypeDTO>> GetPayrollItemTypeList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.PayrollItemType.Where(c => c.IsActive == true).ToListAsync();
                var PayrollItemTypedata = Mapper.Map<IEnumerable<PayrollItemType>, IEnumerable<PayrollItemTypeDTO>>(data);

                PayrollItemTypedata = PayrollItemTypedata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return PayrollItemTypedata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SavePayrollItemType(PayrollItemTypeDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<PayrollItemTypeDTO, PayrollItemType>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<PayrollItemTypeDTO, PayrollItemType>(model);
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
