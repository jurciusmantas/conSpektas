using conSpektas.Data;
using conSpektas.Data.Entities;
using System.Linq;

namespace conSpecktas.Model.Repositories.Categories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ConspectContext _context;

        public CategoriesRepository(ConspectContext context)
        {
            _context = context;
        }

        public Category GetById(int id)
        {
            return _context.Categories.Single(c => c.Id == id);
        }

        public void Insert(ConspectCategory item)
        {
            _context.ConspectsCategories.Add(item);
            _context.SaveChanges();
        }
    }
}
