using Domain.Domain.Entities.File;
using Domain.Interfaces.IRepository.Files;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;

namespace Infrastructure.Repositories.Files
{
    public class MediaEntityRepository : GenericRepository<MediaEntity>, IMediaEntityRepository
    {
        public MediaEntityRepository(DataBaseDbcontext context) : base(context) { }
    }
}
