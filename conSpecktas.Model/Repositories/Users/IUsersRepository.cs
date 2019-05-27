using conSpektas.Data.Entities;

namespace conSpektas.Model.Repositories.Users
{
    public interface IUsersRepository
    {
        User GetUserById(int id);
    }
}