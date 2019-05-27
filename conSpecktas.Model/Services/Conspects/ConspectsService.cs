using conSpecktas.Model.Repositories.Conspects;
using conSpecktas.Model.Services.Categories;
using conSpektas.Data.DTOs;
using conSpektas.Model.Services.Users;
using System;

namespace conSpecktas.Model.Services.Conspects
{
    public class ConspectsService : IConspectsService
    {
        private readonly IConspectsRepository _repository;
        private readonly IUsersService _usersService;
        private readonly ICategoriesService _categoriesService;
        public ConspectsService(IConspectsRepository repository
            , IUsersService usersService
            , ICategoriesService categoriesService)
        {
            _repository = repository;
            _usersService = usersService;
            _categoriesService = categoriesService;
        }

        public conSpektas.Data.Entities.Conspect GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ServerResult UploadConspect(UploadConspectArgs args)
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

                if (string.IsNullOrWhiteSpace(args.Title))
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Title required"
                    };

                if (args.CategoryId == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "CategoryId required"
                    };

                var category = _categoriesService.GetById(args.CategoryId);
                if (category == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = $"Category with id {args.CategoryId} not found"
                    };

                if (args.Content == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Content required"
                    };

                if (args.ParentId.HasValue)
                {
                    var parentConspect = _repository.GetById(args.ParentId.Value);
                    if (parentConspect == null)
                        return new ServerResult
                        {
                            Success = false,
                            Message = $"Parent conspect with id {args.ParentId.Value} not found"
                        };
                }

                var conspectId =_repository.UploadConspect(new conSpektas.Data.Entities.Conspect
                {
                    UserId = user.Id,
                    Title = args.Title,
                    ParentId = args.ParentId,
                    Content = args.Content,
                });

                _categoriesService.Insert(new conSpektas.Data.Entities.ConspectCategory
                {
                    ConspectId = conspectId,
                    CategoryId = category.Id,
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
