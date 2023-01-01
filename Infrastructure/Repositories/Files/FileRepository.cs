using Domain.Domain.Entities.File;
using Domain.Interfaces.IRepository.Files;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Files
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        public FileRepository(DataBaseDbcontext context) : base(context) { }

        public async Task UploadFileAsync(File file)
        {
            await _context.Files.AddAsync(file);
        }

        public async Task<File> GetFileByIdAsync(long id)
        {
            return await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteFileAsync(File file)
        {
            _context.Files.Remove(file);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<File>> GetMediaByIds(List<long> Ids)
        {
            var result = dbSet.Where(w => Ids.Contains(w.Id));

            return result.ToList();
        }

        public async Task<List<File>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
    }
}
