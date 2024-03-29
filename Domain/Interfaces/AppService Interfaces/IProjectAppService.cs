﻿using Domain.Domain.Entities.Healper;
using Domain.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.AppService_Interfaces
{
    public interface IProjectAppService
    {
        List<Project> GetAllProjects(PagingParameters parameters);

    }
}
