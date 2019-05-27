using conSpektas.Data.Entities;

namespace conSpektas.Data.Services.Users
{
    public interface IUsersService
    {
        User GetUserBasic(int id);
    }
}