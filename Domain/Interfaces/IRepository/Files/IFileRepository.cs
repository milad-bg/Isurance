using Domain.Domain.Entities.File;
using Domain.Enums.Flies;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Files
{
    public interface IFileRepository
    {
        Task UploadFileAsync(File file);

        Task<File> GetFileByIdAsync(long id);

        Task DeleteFileAsync(File file);

        Task<bool> SaveChanges();
    }
}
