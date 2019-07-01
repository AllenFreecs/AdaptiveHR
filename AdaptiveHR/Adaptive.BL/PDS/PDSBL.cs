using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Adaptive.BL.docs;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.pds
{
    public class PDSBL : IPDSBL
    {
        private AdaptiveHRContext _dbcontext;
        private IDocsBL _docsBL;
        public PDSBL(AdaptiveHRContext AdaptiveHRContext, IDocsBL docsBL)
        {
            _dbcontext = AdaptiveHRContext;
            _docsBL = docsBL;
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

        public async Task<PDSDTO> GetPDSData(int ID)
        {
            try
            {
                var data = await _dbcontext.Pds.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var PDSdata = Mapper.Map<Pds, PDSDTO>(data);

                return PDSdata;
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
                var PDSdata = Mapper.Map<IEnumerable<Pds>, IEnumerable<PDSDTO>>(data);

                PDSdata = PDSdata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return PDSdata;
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
                int id = model.Id == 0 && model.Image != null ? await _docsBL.UploadDocsBase64(model.Image, "PDS Image") : 0 ;
                var data = Mapper.Map<PDSDTO, Pds>(model);
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {

                        if (model.Id != 0)
                        {
                            _dbcontext.Entry(data).State = EntityState.Modified;
                        }
                        else
                        {
                             data.IdDoc = id;
                            _dbcontext.Entry(data).State = EntityState.Added;
                        }
                        _dbcontext.SaveChanges();
                        transaction.Commit();
                        bool isChildSave = await SavePDSChild(model, data.Id);
                        if (!isChildSave)
                        {
                            throw new Exception();
                        }

                    }
                    catch (Exception ex)
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

        public async Task<bool> SavePDSChild(PDSDTO model, int id)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {

                        foreach (var item in model.WorkExperience)
                        {
                            var Experience = Mapper.Map<JobDTO, Job>(item);
                            Experience.IdPds = id;
                            _dbcontext.Entry(Experience).State = EntityState.Added;
                        }

                        foreach (var item in model.Education)
                        {
                            var Education = Mapper.Map<EducationDTO, Education>(item);
                            Education.IdPds = id;
                            _dbcontext.Entry(Education).State = EntityState.Added;
                        }

                        foreach (var item in model.Seminars)
                        {
                            var Seminar = Mapper.Map<SeminarDTO, Seminar>(item);
                            Seminar.IdPds = id;
                            _dbcontext.Entry(Seminar).State = EntityState.Added;
                        }

                        _dbcontext.SaveChanges();
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                        throw;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }
    }
}
