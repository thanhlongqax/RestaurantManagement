using FileServices.Services;
using Lombok.NET;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileServices.Controllers
{
    [Route("api/file")]
    [ApiController]
    [RequiredArgsConstructor]
    public partial class CloudinaryController : ControllerBase
    {
        private readonly ICloudinaryService _cloudinaryService;

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var response = await _cloudinaryService.UploadFileAsync(file);
            return StatusCode(response.Code, response);
        }

        [HttpPost("upload-multiple")]
        public async Task<IActionResult> UploadMultipleFiles([FromForm] List<IFormFile> files)
        {
            var response = await _cloudinaryService.UploadMultipleFilesAsync(files);
            return StatusCode(response.Code, response);
        }
    }
}
