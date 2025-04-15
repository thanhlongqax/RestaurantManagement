using System.Security.Principal;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using OrderServices.DTO;

namespace FileServices.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger<CloudinaryService> _logger;
        private const long MaxFileSize = 1000L * 1024 * 1024; // 1000MB

        public CloudinaryService(IConfiguration configuration, ILogger<CloudinaryService> logger)
        {
            _logger = logger;
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ResDTO<string>> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0 || file.Length > MaxFileSize)
            {
                return new ResDTO<string> { Code = 400, Message = "Invalid file or file size exceeds 1000MB" };
            }

            using var stream = file.OpenReadStream();
            UploadResult uploadResult;

            if (file.ContentType.StartsWith("video"))
            {
                uploadResult = await _cloudinary.UploadAsync(new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    UseFilename = true,
                    UniqueFilename = true,
                    Overwrite = false
                });
            }
            else
            {
                uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    UseFilename = true,
                    UniqueFilename = true,
                    Overwrite = false
                });
            }

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new ResDTO<string> { Code = 200, Message = "Upload successful", Data = uploadResult.SecureUrl.AbsoluteUri };
            }
            else
            {
                return new ResDTO<string> { Code = 500, Message = uploadResult.Error?.Message };
            }
        }

        public async Task<ResDTO<List<string>>> UploadMultipleFilesAsync(List<IFormFile> files)
        {
            var urls = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > MaxFileSize)
                {
                    return new ResDTO<List<string>> { Code = 400, Message = $"File {file.FileName} exceeds the 1000MB limit" };
                }
                var response = await UploadFileAsync(file);
                if (response.Code == 200 && response.Data != null)
                {
                    urls.Add(response.Data);
                }
            }
            return new ResDTO<List<string>> { Code = 200, Message = "Upload successful", Data = urls };
        }

        public async Task<ResDTO<bool>> DeleteImageAsync(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            var deletionResult = await _cloudinary.DestroyAsync(deletionParams);
            return new ResDTO<bool>
            {
                Code = deletionResult.Result == "ok" ? 200 : 500,
                Message = deletionResult.Result == "ok" ? "Deletion successful" : "Deletion failed",
                Data = deletionResult.Result == "ok"
            };
        }
    }
}
