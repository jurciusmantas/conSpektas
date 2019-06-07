using conSpecktas.Model.Enums;
using conSpecktas.Model.Repositories.Ratings;

namespace conSpecktas.Model.Services.Ratings
{
    public class RatingsService : IRatingsService
    {
        private readonly IRatingsRepository _repository;

        public RatingsService(IRatingsRepository repository)
        {
            _repository = repository;
        }
    }
}
