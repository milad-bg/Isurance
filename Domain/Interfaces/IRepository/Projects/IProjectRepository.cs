using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IGenericRepositores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Projects
{
    public interface IProjectRepository: IGenericRepository<Project>
    {
        Project GetById(long id);
        void DeleteById(long id);
        List<Project> GetProjects(int pageNumber, int pageSize);
        Project GetByTitle(string title);
    }
}
