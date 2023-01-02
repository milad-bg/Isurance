using Application.Servises.Tenders;
using Application.Servises.Tenders.Command;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.Tenders
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ApiController
    {

        private readonly ITenderService _tender;

        public TenderController(ITenderService tender)
        {
            _tender = tender;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddTendreCommand command)
        {
            var tender = await _tender.AddAsync(command);

            if (tender == false)
            {
                return BadRequest();

            }
            return OkResult("Succeed Add tender", tender);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var tender = await _tender.GetAllAdmin();

            return OkResult("Succeed Add tender", tender);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var getTender = await _tender.GetById(id);

            if(getTender == null)
            {
                return BadRequest();
            }

            return OkResult("عملیات موفقیت امیز بود", getTender);
        }


    }
}
