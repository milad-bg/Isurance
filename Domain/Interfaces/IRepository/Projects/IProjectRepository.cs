using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IRepository.Projects.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Projects
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects(int pageNumber, int pageSize);

        Task<Project> AddProjectAsync(Project Project);

        Task<Project> GetByProjectIdAsync(long id);

        Task<Project> EditProjectAsync(Project Project);

        Task<List<Project>> GetAllProjectAsync();

        Task<List<Project>> GetAllProjectWebAsync();

        Task<bool> DeleteProjectAsync(long id);

        Task<bool> DeleteListByIds(List<long> ids);

        Task<List<Project>> GetByIds(List<long> ids);
        
        Task<List<SearchProjectsDto>> SearchInContentAsync(string key);
    }
}
