using Domain.Domain.Entities.Tendor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Tenders
{
    public interface ITenderRepository
    {
        Task<Tender> AddTenderAsync(Tender tender);

        Task<List<Tender>> GetAllProjectAsync();

        Task<Tender> GetById(long id);
    }
}
