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
