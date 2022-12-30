using Domain.Domain.Entities.News;
using Domain.Interfaces.IRepository.News;
using Domain.Interfaces.IRepository.News.Dtos;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.News
{
    public class NewsCastRepository : GenericRepository<NewsCast>, INewsCastRepository
    {
        public NewsCastRepository(DataBaseDbcontext context) : base(context)
        {
        }

        public async Task<NewsCast> AddNewsCastAsync(NewsCast newsCast)
        {
            var result = await InsertReturnAsync(newsCast);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteListByIds(List<long> ids)
        {
            var getNewsCasts = await GetByIds(ids);

            dbSet.RemoveRange(getNewsCasts);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<NewsCast>> GetByIds(List<long> ids)
        {
            return await dbSet.Where(w => ids.Contains(w.Id)).ToListAsync();
        }

        public async Task<bool> DeleteNewsCastAsync(long id)
        {
            await DeleteAsync(id);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<NewsCast> EditNewsCastAsync(NewsCast newsCast)
        {
            var Edit = dbSet.Update(newsCast);

            await _context.SaveChangesAsync();

            return Edit.Entity;
        }

        public async Task<List<NewsCast>> GetAllNewsCastAsync()
        {
            var newsCasts = await GetAll();

            return newsCasts.ToList();
        }

        public async Task<List<NewsCast>> GetAllNewsCastWebAsync(int pageNumber, int pageSize)
        {
            return await dbSet.Where(w => w.IsFeatured == true)
                   .OrderBy(o => o.Priority)
                   .OrderBy(on => on.CreationDate)
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .ToListAsync();
        }

        public async Task<NewsCast> GetByNewsCastIdAsync(long id)
        {
            var newscast = await GetByIdAsync(id);

            return newscast;
        }

        public async Task<List<SearchNewsDto>> SearchInContentAsync(string key)
        {
            return await dbSet
                .Where(w => w.IsFeatured == true && (w.UpperContent.Contains(key) || w.DownContent.Contains(key)))
                .OrderBy(model => model.Title)
                .Take(20)
                .Select(model => new SearchNewsDto
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    UpperContent = model.UpperContent,
                    DownContent = model.DownContent
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<NewsCast>> GetAllWendorList()
        {
            return await dbSet.Where(w => w.IsFeatured == true && w.IsFeaturedPriority == true).ToListAsync();
        }
    }
}
