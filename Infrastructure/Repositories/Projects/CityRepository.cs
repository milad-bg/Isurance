using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IRepository.Projects;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Projects
{
    class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DataBaseDbcontext context) : base(context) { }
    }
}
