using Domain.Domain.Entities.File;
using Domain.Enums;
using Domain.Enums.Flies;
using Domain.Interfaces.IRepository.Files;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> DeleteMeidaByEntityRefAndEntityTypeAndMediaEntityType(long entityRef, EntityType entityType, MediaEntityType mediaEntityType)
        {
            var findMediasAsunc = await FindMediaEntityByEntityRefAndEntityTypeAndMediaEntityType(entityType, entityRef, mediaEntityType);

            dbSet.RemoveRange(findMediasAsunc);

            return await _context.SaveChangesAsync() > 1;
        }

        public async Task<bool> DeleteByEntityRefAndEntityType(long entityRef, EntityType entityType)
        {
            var getmedias = await GetMediasByEntityRefAndEntityType(entityRef, entityType);

            dbSet.RemoveRange(getmedias);

            return await _context.SaveChangesAsync() > 1;
        }

        public async Task<List<MediaEntity>> FindMediaEntityByEntityRefAndEntityTypeAndMediaEntityType(EntityType entityType, long entityRef, MediaEntityType mediaEntityType)
        {
            return await dbSet.Where(x => x.EntityType == entityType && x.EntityRef == entityRef && x.MediaEntityType == mediaEntityType).ToListAsync();
        }

        public async Task<List<MediaEntity>> GetMediasByEntityRefAndEntityType(long entityRef, EntityType entityType)
        {
            return await dbSet.Include(i => i.Media).Where(w => w.EntityRef == entityRef && w.EntityType == entityType).ToListAsync();
        }

        public async Task<List<MediaEntity>> GetByEntityRefsAndEntityType(List<long> entityRefs, EntityType entityType)
        {
            return await dbSet.Where(w => entityRefs.Contains(w.EntityRef) && w.EntityType == entityType).ToListAsync();
        }

        public async Task<bool> DeleteByEnityRefsAndEntityType(List<long> entityRefs, EntityType entityType)
        {
            var getMedias = await GetByEntityRefsAndEntityType(entityRefs, entityType);

            dbSet.RemoveRange(getMedias);

            return await _context.SaveChangesAsync() > 1;
        }

        public async Task<List<MediaEntity>> GetMediasByEntityRefsAndEntityTypeAndMediaEntityType(List<long> entityRefs, EntityType entityType, MediaEntityType mediaEntityType)
        {
            return await dbSet.Include(i => i.Media).Where(w => entityRefs.Contains(w.EntityRef) && w.EntityType == entityType && w.MediaEntityType == mediaEntityType).ToListAsync();
        }
    }
}
