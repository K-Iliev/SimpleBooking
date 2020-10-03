using System.Threading.Tasks;
using Application.Common;
using Application.Identity.Commands;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Features
{
    public class UserController : ApiBaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand createUserCommand)
           => await  this.Send(createUserCommand);
        

        [HttpPost("login")]
        public async Task<ActionResult<LoginSuccessDto>> Login(LoginUserCommand loginUserCommand)
           => await  this.Send(loginUserCommand);
    }
}
