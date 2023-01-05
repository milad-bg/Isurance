using Application.Servises.Files.Commads;
using Application.Servises.Files.Dtos;
using Domain.Enums.Flies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.Files
{

    public interface IFileService
    {
        public string FtpFileUpload(string fileName, MediaEntityType mediaType);

        Task<long?> UploadFileAsync(IFormFile file,FileUploadCommand command);

        Task<FileDto> DownloadFile(long id);

        Task<bool> DeleteFileAsync(long id);

        Task<List<GetAllFileDto>> GetAllMedia();
    }
}
