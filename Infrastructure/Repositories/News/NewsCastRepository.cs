using Domain.Domain.Entities.News;
using Domain.Interfaces.IRepository.News;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
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

        public async Task<bool> DeleteNewsCastAsync(long id)
        {
            return await DeleteAsync(id);
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

        public async Task<NewsCast> GetByNewsCastIdAsync(long id)
        {
            var newscast = await GetByIdAsync(id);

            return newscast;
        }
    }
}
