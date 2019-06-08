namespace conSpecktas.Model.Services.Ratings
{
    public interface IRatingsService
    {
        void AddRatingToConspect(int conspectId, int userId, bool positive);
    }
}