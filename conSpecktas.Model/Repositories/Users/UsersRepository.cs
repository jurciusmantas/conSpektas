using conSpektas.Data;
using conSpektas.Data.Entities;
using System.Linq;

namespace conSpektas.Model.Repositories.Users
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
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }
    }
}
