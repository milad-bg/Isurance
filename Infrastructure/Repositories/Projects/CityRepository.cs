using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IRepository.Projects;
using Domain.Interfaces.IRepository.Projects.Dtos;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Projects
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DataBaseDbcontext context) : base(context) { }

        public async Task<City> AddCityAsync(City city)
        {
            var result = await InsertReturnAsync(city);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteListByIds(List<long> ids)
        {
            var getCitys = await GetByIds(ids);

            dbSet.RemoveRange(getCitys);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<City>> GetByIds(List<long> ids)
        {
            return await dbSet.Where(w => ids.Contains(w.Id)).ToListAsync();
        }

        public async Task<bool> DeleteCityAsync(long id)
        {
            await DeleteAsync(id);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<City> EditCityAsync(City city)
        {
            var Edit = dbSet.Update(city);

            await _context.SaveChangesAsync();

            return Edit.Entity;
        }

        public async Task<List<City>> GetAllCityAsync()
        {
            var citys = await GetAll();

            return citys.ToList();
        }

        public async Task<List<City>> GetAllCityWebAsync()
        {
            return dbSet.Where(w => w.IsFeatured == true).ToList();
        }

        public async Task<City> GetByCityIdAsync(long id)
        {
            var city = await GetByIdAsync(id);

            return city;
        }

        public async Task<List<SearchCityDto>> SearchInContentAsync(string key)
        {
            return await dbSet
                .Where(w => w.IsFeatured == true && w.Title.Contains(key))
                .OrderBy(model => model.Title)
                .Take(20)
                .Select(model => new SearchCityDto
                {
                    Id = model.Id,
                    Title = model.Title
                })
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
