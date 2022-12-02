using Domain.Domain.Entities.File;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Files
{
    public interface IMediaEntityRepository
    {
        Task<bool> AddRangeAsync(List<MediaEntity> mediaEntities);
    }
}
