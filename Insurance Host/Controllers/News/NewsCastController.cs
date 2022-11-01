using Application.Servises.News;
using Application.Servises.News.Commads;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.News
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCastController : ApiController
    {
        private readonly INewsCastService _newsCast;

        public NewsCastController(INewsCastService newsCast)
        {
            _newsCast = newsCast;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddNewsCastCommand command)
        {
            var newsCast = await _newsCast.AddAsync(command);

            return OkResult("Succeed Add News", newsCast);

        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditNewsCastCommand command)
        {
            var newsCast = await _newsCast.EditAsync(command);

            return OkResult("Succeed Edit News", newsCast);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var newsCast = await _newsCast.GetById(id);

            return OkResult("Succeed get News", newsCast);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var newsCast = await _newsCast.GetAllAsync();

            return OkResult("Succeed getAll News", newsCast);
        }
    }
}
