using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;

namespace conSpektas.Data.Services.Login
{
    public interface ILoginService
    {
        ServerResult<User> Login(LoginArgs args);
    }
}