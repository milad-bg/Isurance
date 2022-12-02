using Domain.Domain.Entities.Information;
using Domain.Interfaces.IRepository.Informations;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Information
{
    class ContactUsRepository : GenericRepository<ContactUs>, IContactUsRepository
    {
        public ContactUsRepository(DataBaseDbcontext context) : base(context) { }
    }
}
