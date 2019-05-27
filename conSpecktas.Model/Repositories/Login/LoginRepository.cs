using conSpektas.Data;
using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using System.Linq;

namespace conSpektas.Model.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ConspectContext _context;

        public LoginRepository(ConspectContext context)
        {
            _context = context;
        }

        public User GetUserByLogin(LoginArgs args)
        {
            return _context.Users.Single(u => u.UserName == args.UserName && u.PasswordHash == args.PasswordHash);
        }
    }
}
