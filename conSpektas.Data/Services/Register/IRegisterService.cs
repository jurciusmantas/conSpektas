using conSpektas.Data.DTOs;

namespace conSpektas.Data.Services.Register
{
    public interface IRegisterService
    {
        ServerResult RegisterUser(RegisterArgs args);
    }
}