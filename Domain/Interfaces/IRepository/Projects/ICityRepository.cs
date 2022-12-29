using Domain.Domain.Entities.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Projects
{
    public interface ICityRepository
    {
        Task<City> AddCityAsync(City city);

        Task<City> GetByCityIdAsync(long id);

        Task<City> EditCityAsync(City city);

        Task<List<City>> GetAllCityAsync();

        Task<List<City>> GetAllCityWebAsync();

        Task<bool> DeleteCityAsync(long id);

        Task<bool> DeleteListByIds(List<long> ids);

        Task<List<City>> GetByIds(List<long> ids);
    }
}
