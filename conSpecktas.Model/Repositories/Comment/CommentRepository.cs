using conSpektas.Data;
using conSpektas.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public Data.Entities.Comment GetByIdFull(int commentId)
        {
            return _context.Comments
                .Where(c => c.Id == commentId)
                .Include("Ratings")
                .FirstOrDefault();
        }

        public void UpdateComment(Data.Entities.Comment comment)
        {
            _context.Update(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(Data.Entities.Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}
