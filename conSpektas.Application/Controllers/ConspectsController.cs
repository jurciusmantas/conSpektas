using conSpecktas.Model.Services.Conspects;
using conSpektas.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace conSpektas.Application.Controllers
{
    [Route("api/conspects")]
    public class ConspectsController : ControllerBase
    {
        private readonly IConspectsService _service;

        public ConspectsController(IConspectsService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("upload")]
        public ServerResult UploadConspect([FromBody] UploadConspectArgs args)
        {
            return _service.UploadConspect(args);
        }
    }
}
