using conSpecktas.Model.Repositories.Conspects;
using conSpecktas.Model.Services.Categories;
using conSpecktas.Model.Services.Ratings;
using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using conSpektas.Model.Services.Users;
using System;
using System.Collections.Generic;

namespace conSpecktas.Model.Services.Conspects
{
    public class ConspectsService : IConspectsService
    {
        private readonly IConspectsRepository _repository;
        private readonly IUsersService _usersService;
        private readonly ICategoriesService _categoriesService;
        private readonly IRatingsService _ratingsService;
        public ConspectsService(IConspectsRepository repository
            , IUsersService usersService
            , ICategoriesService categoriesService
            , IRatingsService ratingsService)
        {
            _repository = repository;
            _usersService = usersService;
            _categoriesService = categoriesService;
            _ratingsService = ratingsService;
        }

        public Conspect GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Conspect GetByIdFull(int id)
        {
            return _repository.GetByIdFull(id);
        }

        public ServerResult UploadConspect(UploadConspectArgs args)
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
                    Inserted = DateTime.Now
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

        public ServerResult<List<Conspect>> GetListPaged(GetConspectsListPagedArgs args)
        {
            try
            {
                if (args.PageSize == 0 && args.PageNumber == 0)
                    return new ServerResult<List<Conspect>>
                    {
                        Success = false,
                        Message = "Both page number and page size is 0"
                    };

                return new ServerResult<List<Conspect>>
                {
                    Success = true,
                    Data = _repository.GetConspectsList(args),
                };
            }
            catch (Exception exc)
            {
                return new ServerResult<List<Conspect>>
                {
                    Success = false,
                    Message = exc.Message
                };
            }
        }

        public ServerResult DeleteConspect(int conspectId)
        {
            try
            {
                if (conspectId == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Id cannot be 0!",
                    };

                var conspect = GetByIdFull(conspectId);
                if (conspect == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Conspect not found"
                    };
                // older versions ?

                _repository.DeleteConspect(conspect);
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

        public ServerResult RateConspect(RateConspectArgs args)
        {
            try
            {
                if (args == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Argument object is null"
                    };

                if (args.ConspectId == 0)
                    return new ServerResult
                    {
                        Success = false,
                        Message = "Conspect Id cannot be 0"
                    };

                var conspect = GetById(args.ConspectId);
                if (conspect == null)
                    return new ServerResult
                    {
                        Success = false,
                        Message = $"Conspect with id {args.ConspectId} not found"
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

                _ratingsService.AddRatingToConspect(args.ConspectId, args.UserId, args.Positive);

                if (args.Positive)
                    conspect.Rating++;
                else
                    conspect.Rating--;

                _repository.UpdateConspect(conspect);

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
    }
}
