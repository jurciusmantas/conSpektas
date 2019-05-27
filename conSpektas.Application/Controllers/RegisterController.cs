using conSpektas.Data.DTOs;
using conSpektas.Model.Services.Register;
using Microsoft.AspNetCore.Mvc;

namespace conSpektas.Application.Controllers
{
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        [Route("simple")]
        public ServerResult Register([FromBody] RegisterArgs args)
        {
            return _registerService.RegisterUser(args);
        }
    }
}
