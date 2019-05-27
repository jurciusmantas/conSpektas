using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using conSpektas.Data.Repositories.Login;
using System;

namespace conSpektas.Data.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;

        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public ServerResult<User> Login(LoginArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(args.UserName))
                    return new ServerResult<User>
                    {
                        Success = false,
                        Message = "UserName required"
                    };

                if (string.IsNullOrWhiteSpace(args.PasswordHash))
                    return new ServerResult<User>
                    {
                        Success = false,
                        Message = "PasswordHash required"
                    };

                var user = _repository.GetUserByLogin(args);

                return new ServerResult<User>
                {
                    Success = true,
                    Data = user
                };
            }
            catch(Exception exc)
            {
                return new ServerResult<User>
                {
                    Success = false,
                    Message = exc.Message,
                };
            }
        }
    }
}
