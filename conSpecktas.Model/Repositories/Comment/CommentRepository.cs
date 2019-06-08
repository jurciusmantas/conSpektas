using conSpektas.Data;
using System.Linq;

namespace conSpektas.Model.Repositories.Comment
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ConspectContext _context;

        public CommentRepository(ConspectContext context)
        {
            _context = context;
        }

        public void AddCommentToConspect(Data.Entities.Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public Data.Entities.Comment GetById(int commentId)
        {
            return _context.Comments.SingleOrDefault(c => c.Id == commentId);
        }

        public void UpdateComment(Data.Entities.Comment comment)
        {
            _context.Update(comment);
            _context.SaveChanges();
        }
    }
}
