using System.Collections.Generic;
using conSpektas.Data.Entities;

namespace conSpecktas.Model.Repositories
{
    public interface IDeleteRepository
    {
        void DeleteCommentRatings(int commentId);
        void DeleteCommentsFromConspect(ICollection<Comment> comments);
        void DeleteConspectRatings(ICollection<ConspectRating> ratings);
    }
}