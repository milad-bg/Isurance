using Domain.Domain.Entities.File;
using Domain.Enums;
using Domain.Enums.Flies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Files
{
    public interface IMediaEntityRepository
    {
        Task<bool> AddRangeAsync(List<MediaEntity> mediaEntities);

        Task<bool> DeleteMeidaByEntityRefAndEntityTypeAndMediaEntityType(long entityRef, EntityType entityType, MediaEntityType mediaEntityType);

        Task<List<MediaEntity>> GetMediasByEntityRefsAndEntityTypeAndMediaEntityType(List<long> entityRefs, EntityType entityType, MediaEntityType mediaEntityType);

        Task<List<MediaEntity>> GetMediasByEntityRefAndEntityType(long entityRef, EntityType entityType);

        Task<bool> DeleteByEntityRefAndEntityType(long entityRef, EntityType entityType);

        Task<bool> DeleteByEnityRefsAndEntityType(List<long> entityRefs, EntityType entityType);

        Task<List<MediaEntity>> GetByEntityRefsAndEntityType(List<long> entityRefs, EntityType entityType);
    }
}
