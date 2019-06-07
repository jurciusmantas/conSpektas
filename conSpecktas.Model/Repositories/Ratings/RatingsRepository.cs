using conSpektas.Data;
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
    }
}
