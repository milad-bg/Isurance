using Application.Helper;
using Application.Servises.Files.Commads;
using Application.Servises.Files.Dtos;
using Domain.Interfaces.IRepository.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Servises.Files
{
    public class FileService : IFileService
    {

        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<long?> UploadFileAsync(IFormFile file, FileUploadCommand command)
        {
            var fileName = NameGenerator(file.FileName, out var format);
            //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            var size = file.Length;

            if (format != "png" && format != "jpg" && format != "mp4")
                throw new FormatException("فرمت های معتبر:png/jpg/mp4 خطا\n!");

            switch (format)
            {
                case "png":
                case "jpg" when size > 15000000:
                    throw new InvalidDataException(" حجم عکس شماباید کمتر از15مگابیت باشد!");
                case "mp4" when size > 500000000:
                    throw new InvalidDataException(" حجم فیلم شماباید کمتر از500 مگابایت باشد!");
            }

            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    await file.CopyToAsync(stream);
            //}

            var newFile = new Domain.Domain.Entities.File.File();

            newFile.Url = fileName;
            newFile.Size = size;
            //newFile.FilePath = filePath;
            newFile.Keyword = command.Keword;
            newFile.CreationDate = DateTime.Now;
            newFile.MediaEntity = command.MediaType;

            await _fileRepository.UploadFileAsync(newFile);
            await _fileRepository.SaveChanges();
            return newFile.Id;
        }

        public async Task<FileDto> DownloadFile(long id)
        {
            var File = await _fileRepository.GetFileByIdAsync(id);

            if (File == null)
                throw new ArgumentNullException("فایل مورد نظر یافت نشد");

            var FileDto = new FileDto
            {
                Type = FileFormat.GetMimeType(File.Url.Split('.').Last()),
                Url = "https://plansbox.ir/" + File.Url
            };

            return FileDto;
        }

        public async Task<bool> DeleteFileAsync(long id)
        {
            var file = await _fileRepository.GetFileByIdAsync(id);
            if (file == null)
            {
                throw new ArgumentNullException("فایل مورد نظر یافت نشد");
            }

            await _fileRepository.DeleteFileAsync(file);

            //File.Delete(file.FilePath);

            return await _fileRepository.SaveChanges();
        }

        #region Private_Methods
        private string NameGenerator(string filename, out string format)
        {
            var fileArray = filename.Split(".").ToList();
            var constName = $"{fileArray[0]}MR";
            var randomNumber = new Random().Next(100, 100000).ToString();
            format = fileArray.Last();

            return constName + randomNumber + "." + format;
        }
        #endregion
    }
}
