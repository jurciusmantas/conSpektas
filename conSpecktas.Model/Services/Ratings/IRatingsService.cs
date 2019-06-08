using conSpektas.Data.Entities;

namespace conSpecktas.Model.Services.Ratings
{
    public interface IRatingsService
    {
        void AddRatingToConspect(int conspectId, int userId, bool positive);
        void AddRatingToComment(int commentId, int userId, bool positive);
    }
}