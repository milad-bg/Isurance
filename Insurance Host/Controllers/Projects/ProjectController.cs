using Application.Servises.News.Commads;
using Application.Servises.Projects;
using Domain.Domain.Entities.Healper;
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
    public class ProjectController : ApiController
    {
        private IProjectAppService _project;
        public ProjectController(IProjectAppService appService)
        {
            _project = appService;
        }

        [HttpPost("GetProjects")]
        public async Task<IActionResult> GetProjects([FromBody] PagingParameters parameters)
        {
            var projects = await _project.GetAllProjectsWeb(parameters);

            return OkResult("Succeed getAll projects", projects);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddProjectCommand command)
        {
            var project = await _project.AddAsync(command);

            return OkResult("Succeed Add News", project);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditProjectCommand command)
        {
            var project = await _project.EditAsync(command);

            if (project == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed Edit News", project);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var project = await _project.GetById(id);

            if (project == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed get News", project);
        }

        [HttpGet("GetAllAddmin")]
        public async Task<IActionResult> GetAllAddmin()
        {
            var project = await _project.GetAllAsyncAddmin();

            return OkResult("Succeed getAll News", project);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var project = await _project.DeleteAsync(id);

            if (project == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("حذف با موفقیت انجام شد", project);
        }

        [HttpPost("DeleteList")]
        public async Task<IActionResult> DeleteList([FromBody] List<long> ids)
        {
            var project = await _project.DeleTeListAsync(ids);

            if (project == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("حذف ها با موفقیت انجام شد", project);
        }

        [HttpGet("SearchProject")]
        public async Task<IActionResult> SearchProject(string key)
        {
            var searchNews = await _project.SerachContentAsync(key);

            return OkResult("", searchNews);
        }
    }
}
