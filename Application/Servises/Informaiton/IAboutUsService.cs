using Application.Servises.Informaiton.Commads;
using Application.Servises.Informaiton.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Servises.Informaiton
{
    public interface IAboutUsService
    {
        Task<AddAboutUsDto> AddAsync(AddAboutUsCommand command);

        Task<EditAboutUsDto> EditAsync(EditAboutUsCommand command);

        Task<AboutUsDto> GetById(long id);

        Task<List<GetAboutUsDto>> GetAllAsyncAddmin();

        Task<List<GetAboutUsDto>> GetAllAsyncWeb();

        Task<bool> DeleTeListAsync(List<long> ids);
    }
}
