using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;

namespace conSpektas.Model.Services.Login
{
    public interface ILoginService
    {
        ServerResult<User> Login(LoginArgs args);
    }
}