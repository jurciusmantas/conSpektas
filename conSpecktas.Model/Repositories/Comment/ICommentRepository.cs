using conSpektas.Data.Entities;

namespace conSpektas.Model.Repositories.Comment
{
    public interface ICommentRepository
    {
        void AddCommentToConspect(Data.Entities.Comment comment);
        Data.Entities.Comment GetById(int commentId);
        void UpdateComment(Data.Entities.Comment comment);
        Data.Entities.Comment GetByIdFull(int commentId);
        void DeleteComment(Data.Entities.Comment comment);
    }
}