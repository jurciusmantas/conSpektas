using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;

namespace conSpektas.Model.Repositories.Login
{
    public interface ILoginRepository
    {
        User GetUserByLogin(LoginArgs args);
    }
}