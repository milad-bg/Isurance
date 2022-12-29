using Application.Servises.Cities;
using Application.Servises.Cities.Commads;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.Cities
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ApiController
    {
        private readonly ICityService _city;

        public CityController(ICityService city)
        {
            _city = city;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCityCommand command)
        {
            var city = await _city.AddAsync(command);

            return OkResult("Succeed Add News", city);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditCityCommand command)
        {
            var city = await _city.EditAsync(command);

            if (city == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed Edit News", city);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var city = await _city.GetById(id);

            if (city == null)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed get News", city);
        }

        [HttpGet("GetAllAddmin")]
        public async Task<IActionResult> GetAllAddmin()
        {
            var city = await _city.GetAllAsyncAddmin();

            return OkResult("Succeed getAll News", city);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllWeb()
        {
            var city = await _city.GetAllAsyncWeb();

            return OkResult("Succeed getAll News", city);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var city = await _city.DeleteAsync(id);

            if (city == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("حذف با موفقیت انجام شد", city);
        }

        [HttpPost("DeleteList")]
        public async Task<IActionResult> DeleteList([FromBody] List<long> ids)
        {
            var city = await _city.DeleTeListAsync(ids);

            if (city == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("حذف ها با موفقیت انجام شد", city);
        }

    }
}
