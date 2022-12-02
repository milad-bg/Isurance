using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Servises.News
{
    public interface INewsCastService
    {
        Task<AddNewsCastDto> AddAsync(AddNewsCastCommand command);

        Task<EditNewsCastDto> EditAsync(EditNewsCastCommand command);

        Task<NewsCastDto> GetById(long id);

        Task<List<NewsCastDto>> GetAllAsync();

        Task<bool> DeleteAsync(long id);
    }
}
