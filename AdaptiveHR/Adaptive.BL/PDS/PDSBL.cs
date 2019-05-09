using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Adaptive.BL.Settings;
using AdaptiveHR.Model;
using AdaptiveHR.Util.Encryption;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.PDS
{
    public class PDSBL : IPDSBL
    {
        private AdaptiveHRContext _dbcontext;
        private AppSettings appSettings;
        public PDSBL(AdaptiveHRContext adaptiveHRContext, SettingsBL settingsBL)
        {
            _dbcontext = adaptiveHRContext;
            appSettings = settingsBL.LoadSettings();
        }

        public async Task<GlobalResponseDTO> DeletePDS(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.Pds.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<string> GenerateSessionID()
        {
            try
            {
               
                string SessionExpiy = DateTime.Now.AddMinutes(30).ToString();

             

                string sessionid = await Task.FromResult(RIJEncrypt.Encrypt(SessionExpiy, appSettings.Salt));

                return sessionid;

            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<PDSDTO> GetPDSData(int ID)
        {
            try
            {
                var data = await _dbcontext.Pds.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var pdsdata = Mapper.Map<Pds, PDSDTO>(data);

                return pdsdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<PDSDTO>> GetPDSList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.Pds.Where(c => c.IsActive == true).ToListAsync();
                var pdsdata = Mapper.Map<IEnumerable<Pds>, IEnumerable<PDSDTO>>(data);

                pdsdata = pdsdata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return pdsdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SavePDS(PDSDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<PDSDTO, Pds>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<PDSDTO, Pds>(model);
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

        public bool ValidateSessionID(string sessionid)
        {
            try
            {
                //Check guid authenticity
                string decguid = RIJEncrypt.Decrypt(sessionid, appSettings.Salt);
                DateTime sessionExpiry = Convert.ToDateTime(decguid);
                if ((DateTime.Now - sessionExpiry).TotalMinutes > appSettings.ResetTimeout)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }
    }
}
