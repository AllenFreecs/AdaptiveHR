using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.docs
{
    public interface IDocsBL
    {
        Task<IEnumerable<DocsDTO>> GetDocsList(PageRequest paging);
        Task<DocsDTO> GetDocsData(int ID);
        Task<GlobalResponseDTO> SaveDocs(DocsDTO model);
        Task<GlobalResponseDTO> DeleteDocs(IEnumerable<int> IDs);
        Task<int> UploadDocs(IFormFile file, string Description);
        Task<int> UploadDocsBase64(string Base64, string Description);
    }
}
