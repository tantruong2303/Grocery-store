using Microsoft.AspNetCore.Http;

namespace backend.Utils.Interface
{
    public interface IUploadFileService
    {
        public bool checkFileSize(IFormFile file, int limit);
        public bool checkFileExtension(IFormFile file, string[] extensions);
        public string upload(IFormFile file);
    }
}