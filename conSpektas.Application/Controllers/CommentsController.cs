using conSpektas.Data.DTOs;
using conSpektas.Model.Services.Comments;
using Microsoft.AspNetCore.Mvc;

namespace conSpektas.Application.Controllers
{
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("add/toconspect")]
        public ServerResult AddCommentToConspect([FromBody] AddCommentToConspectArgs args)
        {
            return _service.AddCommentToConspect(args);
        }

        [HttpPost]
        [Route("rate")]
        public ServerResult AddRatingComment([FromBody] RateCommentArgs args)
        {
            return _service.RateComment(args);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ServerResult DeleteComment(int id)
        {
            return _service.DeleteComment(id);
        }
    }
}
