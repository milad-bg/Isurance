using Domain.Interfaces.IRepository.Files;
using Domain.Interfaces.IRepository.Informations;
using Domain.Interfaces.IRepository.News;
using Domain.Interfaces.IRepository.Projects;
using Domain.Interfaces.IRepository.Tenders;
using Domain.Interfaces.IRepository.Users;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.Context;
using Infrastructure.Repositories.Files;
using Infrastructure.Repositories.Information;
using Infrastructure.Repositories.News;
using Infrastructure.Repositories.Projects;
using Infrastructure.Repositories.Tenders;
using Infrastructure.Repositories.Users;
using System.Threading.Tasks;

namespace Infrastructure.UnitOFWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseDbcontext _context;

        public UnitOfWork(DataBaseDbcontext context)
        {
            _context = context;
            File = new FileRepository(_context);
            Media = new MediaEntityRepository(_context);
            AboutUs = new AboutUsRepository(_context);
            ContactUs = new ContactUsRepository(_context);
            Person = new PersonRepository(_context);
            NewsCast = new NewsCastRepository(_context);
            Project = new ProjectRepository(_context);
            City = new CityRepository(_context);
            Tender = new TenderRepository(_context);
            Login = new UserRepository(_context);

        }

        public IFileRepository File { get; private set; }

        public IMediaEntityRepository Media { get; private set; }

        public IAboutUsRepository AboutUs { get; private set; }

        public IContactUsRepository ContactUs { get; private set; }

        public IPersonRepository Person { get; private set; }

        public INewsCastRepository NewsCast { get; private set; }

        public IProjectRepository Project { get; private set; }

        public ICityRepository City { get; private set; }

        public ITenderRepository Tender { get; private set; }

        public IUserRepository Login { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
