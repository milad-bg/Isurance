using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using Application.Servises.Projects.Commads;
using Application.Servises.Projects.Dtos;
using Domain.Domain.Entities.Healper;
using Domain.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.Projects
{
    public interface IProjectAppService
    {
        Task<List<GetProjectDto>> GetAllProjectsWeb(ProjectWebCommad parameters);

        Task<AddProjectDto> AddAsync(AddProjectCommand command);

        Task<EditProjectDto> EditAsync(EditProjectCommand command);

        Task<ProjectDto> GetById(long id);

        Task<List<GetProjectDto>> GetAllAsyncAddmin();

        Task<bool> DeleteAsync(long id);

        Task<bool> DeleTeListAsync(List<long> ids);

        Task<List<SearchProjectDto>> SerachContentAsync(string key);
    }
}
