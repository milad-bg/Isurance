using Application.Servises.Users;
using Application.Servises.Users.Command;
using Finance_fund.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance_Host.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUserservice _user;

        public UserController(IUserservice user)
        {
            _user = user;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var response = await _user.Login(command);

            if (response == false)
            {
                return BadReq(ApiMessage.BadRequest);
            }

            return OkResult("Succeed", response);
        }

    }
}
