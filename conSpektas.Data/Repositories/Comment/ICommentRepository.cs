using conSpektas.Data.Entities;

namespace conSpektas.Data.Repositories.Comment
{
    public interface ICommentRepository
    {
        void AddCommentToConspect(Entities.Comment comment);
    }
}