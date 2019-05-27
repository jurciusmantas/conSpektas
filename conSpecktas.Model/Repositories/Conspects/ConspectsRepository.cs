using conSpektas.Data;
using conSpektas.Data.Entities;
using System.Linq;

namespace conSpecktas.Model.Repositories.Conspects
{
    public class ConspectsRepository : IConspectsRepository
    {
        private readonly ConspectContext _context;

        public ConspectsRepository(ConspectContext context)
        {
            _context = context;
        }

        public Conspect GetById(int id)
        {
            return _context.Conspects.Single(c => c.Id == id);
        }
    }
}
