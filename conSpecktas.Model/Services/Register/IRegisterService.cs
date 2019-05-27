using conSpektas.Data.DTOs;

namespace conSpektas.Model.Services.Register
{
    public interface IRegisterService
    {
        ServerResult RegisterUser(RegisterArgs args);
    }
}