using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using conSpektas.Model.Services.Login;
using Microsoft.AspNetCore.Mvc;

namespace conSpektas.Application.Controllers
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("simple")]
        public ServerResult<User> Login([FromBody] LoginArgs args)
        {
            return _loginService.Login(args);
        }
    }
}
