using conSpektas.Data;

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
        }
    }
}
