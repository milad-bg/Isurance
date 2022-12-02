using Domain.Domain.Entities.Information;
using Domain.Interfaces.IRepository.Informations;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Information
{
    class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DataBaseDbcontext context) : base(context) { }
    }
}
