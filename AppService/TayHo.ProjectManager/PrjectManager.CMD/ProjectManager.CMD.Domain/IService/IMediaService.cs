using Microsoft.AspNetCore.Http;
using Services.Common.Media;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Domain.IService
{
    public interface IMediaService
    {
        //Task<List<MediaResponse>> UploadFileAsync(IEnumerable<IFormFile> formFiles);
        Task<int> SaveFile(IFormFileCollection files, string localtion, string filename, string fullname);
        Task<FileResponse> FetechFiles(string subDirectory);
    }
}
