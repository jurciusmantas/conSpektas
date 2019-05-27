using conSpektas.Data.Entities;

namespace conSpektas.Data.Repositories.Users
{
    public interface IUsersRepository
    {
        User GetUserById(int id);
    }
}