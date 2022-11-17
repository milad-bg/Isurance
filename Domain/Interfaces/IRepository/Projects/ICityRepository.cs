using Domain.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IRepository.Projects
{
    public interface ICityRepository
    {
        City GetById(long id);
        List<City> GetAll();
    }
}
