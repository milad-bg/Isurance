using Application.Servises.Tenders.Command;
using Application.Servises.Tenders.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Servises.Tenders
{
    public interface ITenderService
    {
        Task<bool> AddAsync(AddTendreCommand command);

        Task<List<TendersDto>> GetAllAdmin();

        Task<TendersDto> GetById(long id);
    }
}
