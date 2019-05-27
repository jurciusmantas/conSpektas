using conSpektas.Data.DTOs;

namespace conSpektas.Data.Services.Comments
{
    public interface ICommentService
    {
        ServerResult AddCommentToConspect(AddCommentToConspectArgs args);
    }
}