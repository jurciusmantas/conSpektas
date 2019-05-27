using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;

namespace conSpektas.Data.Repositories.Login
{
    public interface ILoginRepository
    {
        User GetUserByLogin(LoginArgs args);
    }
}