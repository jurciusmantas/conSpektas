using conSpektas.Data.Entities;
using System.Linq;

namespace conSpektas.Data.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ConspectContext _context;

        public UsersRepository(ConspectContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Single(u => u.Id == id);
        }
    }
}
