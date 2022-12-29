using Application.Servises.News;
using Application.Servises.News.Commads;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

            if (newsCast == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed Edit News", newsCast);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var newsCast = await _newsCast.GetById(id);

            if (newsCast == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed get News", newsCast);
        }

        [HttpGet("GetAllAddmin")]
        public async Task<IActionResult> GetAllAddmin()
        {
            var newsCast = await _newsCast.GetAllAsyncAddmin();

            return OkResult("Succeed getAll News", newsCast);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllWeb()
        {
            var newsCast = await _newsCast.GetAllAsyncWeb();

            return OkResult("Succeed getAll News", newsCast);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var newsCast = await _newsCast.DeleteAsync(id);

            if (newsCast == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("حذف با موفقیت انجام شد", newsCast);
        }

        [HttpPost("DeleteList")]
        public async Task<IActionResult> DeleteList([FromBody] List<long> ids)
        {
            var newsCast = await _newsCast.DeleTeListAsync(ids);
            
            if (newsCast == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("حذف ها با موفقیت انجام شد", newsCast);
        }
    }
}
