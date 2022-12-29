using Domain.Domain.Entities.News;
using Domain.Interfaces.IRepository.News.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.News
{
    public interface INewsCastRepository
    {
        Task<NewsCast> AddNewsCastAsync(NewsCast newsCast);

        Task<NewsCast> GetByNewsCastIdAsync(long id);

        Task<NewsCast> EditNewsCastAsync(NewsCast newsCast);

        Task<List<NewsCast>> GetAllNewsCastAsync();

        Task<List<NewsCast>> GetAllNewsCastWebAsync(int pageNumber, int pageSize);

        Task<bool> DeleteNewsCastAsync(long id);

        Task<bool> DeleteListByIds(List<long> ids);

        Task<List<NewsCast>> GetByIds(List<long> ids);

        Task<List<SearchNewsDto>> SearchInContentAsync(string key);
    }
}
