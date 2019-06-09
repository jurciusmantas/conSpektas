using conSpektas.Model.Repositories.Comment;
using conSpektas.Model.Services.Users;
using System;
using conSpektas.Data.DTOs;
using conSpecktas.Model.Services.Conspects;
using conSpecktas.Model.Services.Ratings;
using conSpektas.Data.Entities;
using conSpecktas.Model.Services;
using System.Linq;

namespace conSpektas.Model.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUsersService _usersService;
        private readonly ICommentRepository _repository;
        private readonly IConspectsService _conspectsService;
        private readonly IRatingsService _ratingsService;

        public CommentService(ICommentRepository repository
            , IUsersService usersService
            , IConspectsService conspectsService
            , IRatingsService ratingsService)
        {
            _repository = repository;
            _usersService = usersService;
            _conspectsService = conspectsService;
            _ratingsService = ratingsService;
        }

        public Comment GetById(int commentId)
        {
            return _repository.GetById(commentId);
        }

        public Comment GetByIdFull(int commentId)
        {
            return _repository.GetByIdFull(commentId);
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

        public ServerResult RateComment(RateCommentArgs args)
        {
            try
            {
                if (args == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Argument object is null"
                    };

                if (args.CommentId == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Conspect Id cannot be 0"
                    };

                var comment = GetById(args.CommentId);
                if (comment == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = $"Comment with id {args.CommentId} not found"
                    };

                if (args.UserId == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "User Id cannot be 0"
                    };

                var user = _usersService.GetUserBasic(args.UserId);
                if (user == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = $"User with id {args.UserId} not found"
                    };

                _ratingsService.AddRatingToComment(args.CommentId, args.UserId, args.Positive);

                if (args.Positive)
                    comment.Rating++;
                else
                    comment.Rating--;

                _repository.UpdateComment(comment);

                return new ServerResult { Success = true };
            }
            catch (Exception exc)
            {
                return new ServerResult
                {
                    Success = false,
                    Message = exc.Message,
                };
            }
        }

        public ServerResult DeleteComment(int id)
        {
            try
            {
                if (id == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Id cannot be 0"
                    };

                var comment = GetByIdFull(id);
                if (comment == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = $"Comment with id {id} not found"
                    };

                _repository.DeleteComment(comment);

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
