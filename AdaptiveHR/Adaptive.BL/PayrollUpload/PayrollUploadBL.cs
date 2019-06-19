using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.payrollupload
{
    public class PayrollUploadBL : IPayrollUploadBL
    {
        private AdaptiveHRContext _dbcontext;
        public PayrollUploadBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeletePayrollUpload(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.PayrollUpload.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<PayrollUploadDTO> GetPayrollUploadData(int ID)
        {
            try
            {
                var data = await _dbcontext.PayrollUpload.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var PayrollUploaddata = Mapper.Map<PayrollUpload, PayrollUploadDTO>(data);

                return PayrollUploaddata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<PayrollUploadDTO>> GetPayrollUploadList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.PayrollUpload.Where(c => c.IsActive == true).ToListAsync();
                var PayrollUploaddata = Mapper.Map<IEnumerable<PayrollUpload>, IEnumerable<PayrollUploadDTO>>(data);

                PayrollUploaddata = PayrollUploaddata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return PayrollUploaddata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SavePayrollUpload(PayrollUploadDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<PayrollUploadDTO, PayrollUpload>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<PayrollUploadDTO, PayrollUpload>(model);
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
