using Domain.Domain.Entities.Healper;
using Domain.Interfaces.AppService_Interfaces;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController: ApiController
    {
        private IProjectAppService _appService;
        public ProjectController(IProjectAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("GetProjects")]
        public IActionResult GetProjects([FromBody] PagingParameters parameters)
        {
            var projects = _appService.GetAllProjects(parameters);
            return OkResult(ApiMessage.Ok, projects);
        }
    }
}
