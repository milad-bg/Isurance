using Domain.Interfaces.IGenericRepositores;
using Domain.Interfaces.IRepository.Files;
using Domain.Interfaces.IRepository.Informations;
using Domain.Interfaces.IRepository.News;
using Domain.Interfaces.IRepository.Projects;
using Domain.Interfaces.IRepository.Tenders;
using Domain.Interfaces.IRepository.Users;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IFileRepository File { get; }

        IMediaEntityRepository Media { get; }

        IAboutUsRepository AboutUs { get; }

        IContactUsRepository ContactUs { get; }

        IPersonRepository Person { get; }

        INewsCastRepository NewsCast { get; }

        IProjectRepository Project { get; }

        ICityRepository City { get; }

        ITenderRepository Tender { get; }

        IUserRepository User { get; }

        Task CompleteAsync();
    }
}
