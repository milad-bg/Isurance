using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using Domain.Domain.Entities.Healper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Servises.News
{
    public interface INewsCastService
    {
        Task<AddNewsCastDto> AddAsync(AddNewsCastCommand command);

        Task<EditNewsCastDto> EditAsync(EditNewsCastCommand command);

        Task<NewsCastDto> GetById(long id);

        Task<List<GetNewsCastDto>> GetAllAsyncAddmin();

        Task<List<GetNewsCastDto>> GetAllWendorList();

        Task<List<GetNewsCastDto>> GetAllAsyncWeb(PagingParameters parameters);

        Task<bool> DeleteAsync(long id);

        Task<bool> DeleTeListAsync(List<long> ids);

        Task<List<SearchNewsCastDto>> SerachContentAsync(string key);
    }
}
