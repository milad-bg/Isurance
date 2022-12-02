using Domain.Domain.Entities.Tendor;
using Domain.Interfaces.IRepository.Tenders;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Tenders
{
    public class TenderRepository : GenericRepository<Tender>, ITenderRepository
    {
        public TenderRepository(DataBaseDbcontext context) : base(context) { }

    }
}
