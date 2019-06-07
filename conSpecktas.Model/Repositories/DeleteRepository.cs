using System.Collections.Generic;
using System.Linq;
using conSpektas.Data;
using conSpektas.Data.Entities;

namespace conSpecktas.Model.Repositories
{
    public class DeleteRepository : IDeleteRepository
    {
        private readonly ConspectContext _context;

        public DeleteRepository(ConspectContext context)
        {
            _context = context;
        }

        public void DeleteCommentRatings(int commentId)
        {
            var commentRatings = _context.CommentsRatings.Where(cr => cr.CommentId == commentId).ToList(); 
            _context.CommentsRatings.RemoveRange(commentRatings);
            _context.SaveChanges();
        }

        public void DeleteCommentsFromConspect(ICollection<Comment> comments)
        {
            _context.Comments.RemoveRange(comments);
            _context.SaveChanges();
        }

        public void DeleteConspectRatings(ICollection<ConspectRating> ratings)
        {
            _context.ConspectsRatings.RemoveRange(ratings);
            _context.SaveChanges();
        }
    }
}
