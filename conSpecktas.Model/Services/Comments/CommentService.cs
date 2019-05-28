using conSpektas.Model.Repositories.Comment;
using conSpektas.Model.Services.Users;
using System;
using conSpektas.Data.DTOs;
using conSpecktas.Model.Services.Conspects;

namespace conSpektas.Model.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUsersService _usersService;
        private readonly ICommentRepository _repository;
        private readonly IConspectsService _conspectsService;

        public CommentService(ICommentRepository repository
            , IUsersService usersService
            , IConspectsService conspectsService)
        {
            _repository = repository;
            _usersService = usersService;
            _conspectsService = conspectsService;
        }

        public ServerResult AddCommentToConspect(AddCommentToConspectArgs args)
        {
            try
            {
                if (args == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Failed to get argument object"
                    };

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

                var conspect = _conspectsService.GetById(args.ConspectId);
                if (conspect == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = $"Conspect with id {args.ConspectId} not found"
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
                    ConspectId = conspect.Id,
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
