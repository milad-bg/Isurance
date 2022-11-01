using Domain.Domain.Entities.File;
using Domain.Interfaces.IRepository.Files;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;

namespace Infrastructure.Repositories.Files
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        public FileRepository(DataBaseDbcontext context) : base(context) { }
    }
}
