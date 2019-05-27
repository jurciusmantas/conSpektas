using conSpektas.Model.Repositories.Comment;
using conSpektas.Model.Services.Users;
using System;
using conSpektas.Data.DTOs;

namespace conSpektas.Model.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUsersService _usersService;
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository
            , IUsersService usersService)
        {
            _repository = repository;
            _usersService = usersService;
        }

        public ServerResult AddCommentToConspect(AddCommentToConspectArgs args)
        {
            try
            {
                if (args.UserId == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "UserId required"
                    };

                var user = _usersService.GetUserBasic(args.UserId);
                if (user == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = $"User with id {args.UserId} not found"
                    };

                if (args.ConspectId == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "ConspectId required"
                    };

                if (string.IsNullOrWhiteSpace(args.Content))
                    return new ServerResult
                    {
                        Success = false,
                        Message = "UserId required"
                    };

                _repository.AddCommentToConspect(new Data.Entities.Comment
                {
                    UserId = user.Id,
                    ConspectId = args.ConspectId, // veliau var conspect = _conspectService;
                    Content = args.Content
                });

                return new ServerResult { Success = true };
            }
            catch (Exception exc)
            {
                return new ServerResult
                {
                    Success = false,
                    Message = exc.Message
                };
            }
        }
    }
}
