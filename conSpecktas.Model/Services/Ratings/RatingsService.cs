using conSpecktas.Model.Enums;
using conSpecktas.Model.Repositories.Ratings;
using conSpektas.Data.Entities;

namespace conSpecktas.Model.Services.Ratings
{
    public class RatingsService : IRatingsService
    {
        private readonly IRatingsRepository _repository;

        public RatingsService(IRatingsRepository repository)
        {
            _repository = repository;
        }

        public void AddRatingToComment(int commentId, int userId, bool positive)
        {
            var commentRating = new CommentRating
            {
                CommentId = commentId,
                UserId = userId,
                Positive = positive,
            };

            _repository.InsertCommentRating(commentRating);
        }

        public void AddRatingToConspect(int conspectId, int userId, bool positive)
        {
            var conspectRating = new ConspectRating
            {
                ConspectId = conspectId,
                UserId = userId,
                Positive = positive,
            };

            _repository.InsertConspectRating(conspectRating);
        }
    }
}
