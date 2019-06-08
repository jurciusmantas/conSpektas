using conSpecktas.Model.Services.Conspects;
using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

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

        [HttpPost]
        [Route("list_paged")]
        public ServerResult<List<Conspect>> GetListPaged([FromBody] GetConspectsListPagedArgs args)
        {
            return _service.GetListPaged(args);
        }

        [HttpGet]
        [Route("delete/{conspectId}")]
        public ServerResult DeleteConspect(int conspectId)
        {
            return _service.DeleteConspect(conspectId);
        }

        [HttpPost]
        [Route("rate")]
        public ServerResult AddRatingToConspect([FromBody] RateConspectArgs args)
        {
            return _service.RateConspect(args);
        }
    }
}
