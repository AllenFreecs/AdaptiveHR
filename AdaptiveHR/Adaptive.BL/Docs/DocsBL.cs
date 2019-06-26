using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AdaptiveHR.Adaptive.BL.docs
{
    public class DocsBL : IDocsBL
    {
        private AdaptiveHRContext _dbcontext;
        public DocsBL(AdaptiveHRContext AdaptiveHRContext)
        {
            _dbcontext = AdaptiveHRContext;
        }

        public async Task<GlobalResponseDTO> DeleteDocs(IEnumerable<int> IDs)
        {
            try
            {
                foreach (var item in IDs)
                {
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.Docs.Where(c => c.Id == item).SingleOrDefault();
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

        public async Task<DocsDTO> GetDocsData(int ID)
        {
            try
            {
                var data = await _dbcontext.Docs.Where(c => c.Id == ID && c.IsActive == true).SingleOrDefaultAsync();
                var Docsdata = Mapper.Map<Docs, DocsDTO>(data);

                return Docsdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<IEnumerable<DocsDTO>> GetDocsList(PageRequest paging)
        {
            try
            {
                var data = await _dbcontext.Docs.Where(c => c.IsActive == true).ToListAsync();
                var Docsdata = Mapper.Map<IEnumerable<Docs>, IEnumerable<DocsDTO>>(data);

                Docsdata = Docsdata.Skip((paging.Page - 1) * paging.Pagesize).Take(paging.Pagesize).ToList();
                return Docsdata;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> SaveDocs(DocsDTO model)
        {
            try
            {
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != 0)
                        {

                            var data = Mapper.Map<DocsDTO, Docs>(model);
                            _dbcontext.Entry(data).State = EntityState.Modified;

                        }
                        else
                        {
                            var data = Mapper.Map<DocsDTO, Docs>(model);
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

        public async Task<int> UploadDocs(IFormFile file, string Description)
        {
            try
            {
                string NewFileName = Guid.NewGuid().ToString();
                var filepath = Path.Combine(Environment.CurrentDirectory, "Archive", NewFileName);
                Docs doc = new Docs();
                doc.Title = NewFileName;
                doc.Description = Description;

                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbcontext.Entry(doc).State = EntityState.Added;
                        _dbcontext.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return 0;
                        throw;
                    }
                }
                return doc.Id;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }
    }
}
