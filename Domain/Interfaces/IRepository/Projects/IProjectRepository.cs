using Domain.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Projects
{
    public interface IProjectRepository
    {
        List<Project> GetProjects(int pageNumber, int pageSize);
    }
}
