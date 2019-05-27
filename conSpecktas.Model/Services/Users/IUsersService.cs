using conSpektas.Data.Entities;

namespace conSpektas.Model.Services.Users
{
    public interface IUsersService
    {
        User GetUserBasic(int id);
    }
}