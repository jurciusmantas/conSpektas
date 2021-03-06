﻿using conSpektas.Data;
using conSpektas.Data.Entities;
using System.Linq;

namespace conSpecktas.Model.Repositories.Ratings
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly ConspectContext _context;

        public RatingsRepository(ConspectContext context)
        {
            _context = context;
        }

        public void InsertCommentRating(CommentRating commentRating)
        {
            _context.CommentsRatings.Add(commentRating);
            _context.SaveChanges();
        }

        public void InsertConspectRating(ConspectRating conspectRating)
        {
            _context.ConspectsRatings.Add(conspectRating);
            _context.SaveChanges();
        }
    }
}
