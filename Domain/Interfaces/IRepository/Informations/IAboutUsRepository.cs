using Domain.Domain.Entities.Information;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Informations
{
    public interface IAboutUsRepository
    {
        Task<AboutUs> AddAboutUsAsync(AboutUs city);

        Task<AboutUs> GetByAboutUsIdAsync(long id);

        Task<AboutUs> EditAboutUsAsync(AboutUs city);

        Task<List<AboutUs>> GetAllAboutUsAsync();

        Task<List<AboutUs>> GetAllAboutUsWebAsync();

        Task<bool> DeleteAboutUsAsync(long id);

        Task<bool> DeleteListByIds(List<long> ids);

        Task<List<AboutUs>> GetByIds(List<long> ids);
    }
}
