using conSpektas.Data.Entities;

namespace conSpecktas.Model.Repositories.Ratings
{
    public interface IRatingsRepository
    {
        void InsertConspectRating(ConspectRating conspectRating);
        void InsertCommentRating(CommentRating commentRating);
    }
}