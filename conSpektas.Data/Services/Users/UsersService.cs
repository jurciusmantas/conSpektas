using conSpektas.Data.Entities;
using conSpektas.Data.Repositories.Users;

namespace conSpektas.Data.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public User GetUserBasic(int id)
        {
            return _repository.GetUserById(id);
        }
    }
}
