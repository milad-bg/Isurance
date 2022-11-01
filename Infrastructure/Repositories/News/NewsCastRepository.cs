using Domain.Domain.Entities.News;
using Domain.Interfaces.IRepository.News;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.News
{
    class NewsCastRepository : GenericRepository<NewsCast>, INewsCastRepository
    {
        public NewsCastRepository(DataBaseDbcontext context) : base(context) { }
    }
}
