using conSpektas.Data.Entities;

namespace conSpektas.Model.Repositories.Comment
{
    public interface ICommentRepository
    {
        void AddCommentToConspect(Data.Entities.Comment comment);
    }
}