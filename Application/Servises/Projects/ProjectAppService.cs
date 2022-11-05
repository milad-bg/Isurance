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
        public List<Project> GetAllProjects(PagingParameters parameters)
        {
            return _unitOfWork.Project
                .GetProjects(parameters.PageNumber, parameters.PageSize);
        }
    }
}
