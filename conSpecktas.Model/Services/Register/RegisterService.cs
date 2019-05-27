using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using conSpektas.Model.Repositories.Register;
using System;

namespace conSpektas.Model.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _repository;

        public RegisterService(IRegisterRepository repository)
        {
            _repository = repository;
        }

        public ServerResult RegisterUser(RegisterArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(args.FirstName))
                    return new ServerResult
                    {
                        Success = false,
                        Message = "FirstName required"
                    };

                if (string.IsNullOrWhiteSpace(args.LastName))
                    return new ServerResult
                    {
                        Success = false,
                        Message = "LastName required"
                    };

                if (string.IsNullOrWhiteSpace(args.UserName))
                    return new ServerResult
                    {
                        Success = false,
                        Message = "UserName required"
                    };

                if (string.IsNullOrWhiteSpace(args.PasswordHash))
                    return new ServerResult
                    {
                        Success = false,
                        Message = "PasswordHash required"
                    };

                if (args.UserName.Length < 4)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "User Name too short (min 4 characters)"
                    };

                User user = new User
                {
                    FirstName = args.FirstName,
                    LastName = args.LastName,
                    UserName = args.UserName,
                    PasswordHash = args.PasswordHash,
                    Email = args.Email ?? null,
                    Institution = args.Institution ?? null,
                };

                _repository.AddUser(user);
                return new ServerResult { Success = true };
            }
            catch (Exception e)
            {
                return new ServerResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
