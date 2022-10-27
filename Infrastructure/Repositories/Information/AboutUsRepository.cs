using Domain.Domain.Entities.Information;
using Domain.Interfaces.IRepository.Informations;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;

namespace Infrastructure.Repositories.Information
{
    class AboutUsRepository : GenericRepository<AboutUs>, IAboutUsRepository
    {
        public AboutUsRepository(DataBaseDbcontext context) : base(context) { }
    }
}
