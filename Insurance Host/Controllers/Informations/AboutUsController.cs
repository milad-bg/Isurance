using Application.Servises.Informaiton;
using Application.Servises.Informaiton.Commads;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.Informations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ApiController
    {
        private readonly IAboutUsService _aboutUs;

        public AboutUsController(IAboutUsService aboutUs)
        {
            _aboutUs = aboutUs;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddAboutUsCommand command)
        {
            var AboutUs = await _aboutUs.AddAsync(command);

            return OkResult("Succeed Add News", AboutUs);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditAboutUsCommand command)
        {
            var city = await _aboutUs.EditAsync(command);

            if (city == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed Edit News", city);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var city = await _aboutUs.GetById(id);

            if (city == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed get News", city);
        }

        [HttpGet("GetAllAdmin")]
        public async Task<IActionResult> GetAllAdmin()
        {
            var city = await _aboutUs.GetAllAsyncAddmin();

            return OkResult("Succeed getAll News", city);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllWeb()
        {
            var city = await _aboutUs.GetAllAsyncWeb();

            return OkResult("Succeed getAll News", city);
        }

        [HttpPost("DeleteList")]
        public async Task<IActionResult> DeleteList([FromBody] List<long> ids)
        {
            var city = await _aboutUs.DeleTeListAsync(ids);

            if (city == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("حذف ها با موفقیت انجام شد", city);
        }
    }
}
