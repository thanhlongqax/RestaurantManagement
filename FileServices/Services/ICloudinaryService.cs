using OrderServices.DTO;

namespace FileServices.Services
{
    public interface ICloudinaryService
    {
        Task<ResDTO<string>> UploadFileAsync(IFormFile file);
        Task<ResDTO<List<string>>> UploadMultipleFilesAsync(List<IFormFile> files);
        Task<ResDTO<bool>> DeleteImageAsync(string publicId);
    }
}
