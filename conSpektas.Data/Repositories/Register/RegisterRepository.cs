using conSpektas.Data.Entities;

namespace conSpektas.Data.Repositories.Register
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ConspectContext _context;

        public RegisterRepository(ConspectContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
    }
}
