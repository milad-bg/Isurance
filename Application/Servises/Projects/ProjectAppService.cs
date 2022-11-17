using Domain.Commands;
using Domain.Domain.Entities.Healper;
using Domain.Domain.Entities.Projects;
using Domain.Interfaces.AppService_Interfaces;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.UnitOFWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.Projects
{
    public class ProjectAppService : IProjectAppService
    {
        private IUnitOfWork _unitOfWork;
        public ProjectAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // TODO: milad -> i have to async this method and put await before Complete method(because it wasnt inserting in db but i was getting true result)
        public bool AddProject(AddProjectCommand projectCommand)
        {
            var project = ToProject(projectCommand);
            _unitOfWork.Project.InsertAsync(project);
            _unitOfWork.Complete();
            return true;

            #region Local Functions
            Project ToProject(AddProjectCommand projectCommand)
            {
                return new Project()
                {
                    City = ToCity(projectCommand.City),
                    Content = projectCommand.Content,
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    Description = projectCommand.Description,
                    Priority = projectCommand.Priority,
                    State = projectCommand.State,
                    Title = projectCommand.Title
                };
            }

            City ToCity(AddAndUpdateCityCommand cityCommand)
            {
                if (cityCommand.Id == 0)
                {
                    return new City()
                    {
                        Name = cityCommand.Name,
                        CreationDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now
                    };
                }
                else
                {
                    return
                    _unitOfWork.City
                        .GetById(cityCommand.Id);
                }

            }

            #endregion
        }

        public void DeleteProject(long id)
        {
            _unitOfWork.Project
                .DeleteById(id);

            _unitOfWork.Complete();
        }

        public List<Project> GetAllProjects(PagingParameters parameters)
        {
            return _unitOfWork.Project
                .GetProjects(parameters.PageNumber, parameters.PageSize);
        }

        public void UpdateProject(UpdateProjectCommand updateProjectCommand)
        {
            var project = _unitOfWork.Project
                .GetById(updateProjectCommand.Id);

            project.Update(updateProjectCommand);

            _unitOfWork.Complete();
        }

        public Project GetById(long id)
        {
            return _unitOfWork.Project
                .GetByIdAsync(id).Result;
        }

        public Project GetByTitle(string title)
        {
            return
            _unitOfWork.Project.GetByTitle(title);
        }
    }
}
