using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IRepository.Projects;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.Projects
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DataBaseDbcontext context) : base(context) { }

        public City GetById(long id)
        {
            return 
            dbSet.Find(id);
        }

        public List<City> GetAll()
        {
            return
            dbSet.ToList();
        }
    }
}
