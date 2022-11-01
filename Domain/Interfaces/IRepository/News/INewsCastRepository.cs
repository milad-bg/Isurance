using Domain.Domain.Entities.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.News
{
    public interface INewsCastRepository
    {
        Task<bool> AddNewsCastAsync(NewsCast newsCast);

        Task<NewsCast> GetByNewsCastIdAsync(long id);

        Task<NewsCast> EditNewsCastAsync(NewsCast newsCast);

        Task<List<NewsCast>> GetAllNewsCastAsync();
    }
}
