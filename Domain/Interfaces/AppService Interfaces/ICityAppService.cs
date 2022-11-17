using Domain.Domain.Entities.Projects;
using Domain.Dto_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.AppService_Interfaces
{
    public interface ICityAppService
    {
        List<CityDto> GetAll();
    }
}
