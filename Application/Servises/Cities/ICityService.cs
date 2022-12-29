using Application.Servises.Cities.Commads;
using Application.Servises.Cities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Servises.Cities
{
    public interface ICityService
    {
        Task<AddCityDto> AddAsync(AddCityCommand command);

        Task<EditCityDto> EditAsync(EditCityCommand command);

        Task<CityDto> GetById(long id);

        Task<List<GetCityDto>> GetAllAsyncAddmin();

        Task<List<GetCityDto>> GetAllAsyncWeb();

        Task<bool> DeleteAsync(long id);

        Task<bool> DeleTeListAsync(List<long> ids);
    }
}
