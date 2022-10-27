using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IRepository.Projects;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Projects
{
    class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataBaseDbcontext context) : base(context) { }

    }
}
