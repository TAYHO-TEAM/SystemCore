using Microsoft.AspNetCore.Http;
using Services.Common.Media;
using System;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Domain.IService
{
    public interface IMediaService
    {
        //Task<List<MediaResponse>> UploadFileAsync(IEnumerable<IFormFile> formFiles);
        Task<Tuple<string, string, string>> SaveFile(IFormFile files, string Folder, string filename);
        Task<FileResponse> FetechFiles(string subDirectory);
    }
}
