using Domain.Domain.Entities.Information;
using Domain.Interfaces.IRepository.Informations;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Information
{
    public class AboutUsRepository : GenericRepository<AboutUs>, IAboutUsRepository
    {
        public AboutUsRepository(DataBaseDbcontext context) : base(context) { }

        public async Task<AboutUs> AddAboutUsAsync(AboutUs aboutUs)
        {
            var result = await InsertReturnAsync(aboutUs);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteListByIds(List<long> ids)
        {
            var getAboutUss = await GetByIds(ids);

            dbSet.RemoveRange(getAboutUss);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AboutUs>> GetByIds(List<long> ids)
        {
            return await dbSet.Where(w => ids.Contains(w.Id)).ToListAsync();
        }

        public async Task<bool> DeleteAboutUsAsync(long id)
        {
            await DeleteAsync(id);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AboutUs> EditAboutUsAsync(AboutUs aboutUs)
        {
            var Edit = dbSet.Update(aboutUs);

            await _context.SaveChangesAsync();

            return Edit.Entity;
        }

        public async Task<List<AboutUs>> GetAllAboutUsAsync()
        {
            return await dbSet.Include(i => i.Persons).ToListAsync();
        }

        public async Task<List<AboutUs>> GetAllAboutUsWebAsync()
        {
            return await dbSet.Include(e=>e.Persons).ToListAsync();
        }

        public async Task<AboutUs> GetByAboutUsIdAsync(long id)
        {
            return await dbSet.Include(f => f.Persons).FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
