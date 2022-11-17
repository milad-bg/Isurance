using Domain.Interfaces.AppService_Interfaces;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.Projects
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CityController: ApiController
    {
        private ICityAppService _appService;
        public CityController(ICityAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var cities = _appService.GetAll();
            return OkResult(ApiMessage.Ok, cities);
        }
    }
}
