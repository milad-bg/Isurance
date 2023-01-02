using Application.Helper;
using Application.Servises.Files.Commads;
using Application.Servises.Files.Dtos;
using AutoMapper;
using Domain.Interfaces.IRepository.Files;
using Domain.Interfaces.IUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Servises.Files
{
    public class FileService : IFileService
    {

        private readonly IFileRepository _fileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public FileService(IFileRepository fileRepository,
            IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {                                    
            _fileRepository = fileRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }                   

        public async Task<long?> UploadFileAsync(IFormFile file, FileUploadCommand command)
        {
            try
            {
                var fileName = NameGenerator(file.FileName, out var format);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

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

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var newFile = new Domain.Domain.Entities.File.File();

                newFile.Url = fileName;
                newFile.Size = size;
                newFile.FilePath = filePath;
                newFile.CreationDate = DateTime.Now;
                newFile.MediaEntity = command.MediaType;

                await _fileRepository.UploadFileAsync(newFile);
                await _fileRepository.SaveChanges();
                return newFile.Id;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(FileService));

                throw new Exception("erro catch");
            }


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

            File.Delete(file.FilePath);

            return await _fileRepository.SaveChanges();
        }

        public async Task<List<GetAllFileDto>> GetAllMedia()
        {
            var listDto = new List<GetAllFileDto>();

            try
            {
                var getAllImage = await _unitOfWork.File.GetAll();

                foreach (var image in getAllImage)
                {
                    image.Url = "https://plansbox.ir/" + image.Url;

                    listDto.Add(new GetAllFileDto()
                    {
                        Url = image.Url,
                        Id = image.Id
                    });
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(FileService));

                throw new Exception("erro catch");
            }

            return listDto;
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
