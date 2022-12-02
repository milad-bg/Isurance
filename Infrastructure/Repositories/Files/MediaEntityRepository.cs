using Domain.Domain.Entities.File;
using Domain.Interfaces.IRepository.Files;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Files
{
    public class MediaEntityRepository : GenericRepository<MediaEntity>, IMediaEntityRepository
    {
        public MediaEntityRepository(DataBaseDbcontext context) : base(context) { }

        public async Task<bool> AddRangeAsync(List<MediaEntity> mediaEntities)
        {
            await AddRange(mediaEntities);

            return await _context.SaveChangesAsync() > 1;
        }
    }
}
