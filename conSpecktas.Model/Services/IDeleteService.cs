using System.Collections.Generic;
using conSpektas.Data.Entities;

namespace conSpecktas.Model.Services
{
    public interface IDeleteService
    {
        void DeleteCommentsFromConspect(Conspect conspect);
        void DeleteConspectRatings(ICollection<ConspectRating> ratings);
    }
}