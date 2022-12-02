using Application.Servises.Files;
using Application.Servises.Files.Commads;
using Domain.Enums.Flies;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.Files
{
    [Route("api/[controller]")]
    [ApiController]

    public class FileController : ApiController
    {
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;

        public FileController(IFileService fileService, IWebHostEnvironment environment)
        {
            _fileService = fileService;
            _environment = environment;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file, [FromForm] FileUploadCommand command)
        {

            var result = await _fileService.UploadFileAsync(file, command);

            if (result == null)
                BadReq("فایل اضافه نشد");

            return OkResult("فایل با موفقیت اضافه شد", result);
        }

        [HttpGet("{id}/Download")]
        public async Task<IActionResult> DownloadPicsAsync(long id)
        {
            var myFile = await _fileService.DownloadFile(id);

            if (myFile.Bytes == null)
                BadReq(ApiMessage.BadRequest);

            return OkResult(ApiMessage.Ok, myFile);
        }

        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteFileAsync(long id)
        {
            var result = await _fileService.DeleteFileAsync(id);

            if (!result)
                return BadReq(ApiMessage.BadRequest);

            return OkResult("فایل با موفقیت حذف شد");

        }

        [HttpGet]
        public async Task<IActionResult> GetImage(string imageName)
        {

            Byte[] b;
            b = await System.IO.File.ReadAllBytesAsync(Path.Combine(_environment.ContentRootPath, "Images", $"{imageName}"));
            return File(b, "image/jpeg");
        }
    }
}
