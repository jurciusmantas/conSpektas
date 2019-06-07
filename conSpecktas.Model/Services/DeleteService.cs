using System.Collections.Generic;
using conSpecktas.Model.Repositories;
using conSpektas.Data.Entities;

namespace conSpecktas.Model.Services
{
    public class DeleteService : IDeleteService
    {
        private readonly IDeleteRepository _repository;

        public DeleteService(IDeleteRepository repository)
        {
            _repository = repository;
        }

        public void DeleteCommentsFromConspect(Conspect conspect)
        {
            if (conspect == null)
                return;

            foreach (var comment in conspect.Comments)
                _repository.DeleteCommentRatings(comment.Id);

            _repository.DeleteCommentsFromConspect(conspect.Comments);
        }

        public void DeleteConspectRatings(ICollection<ConspectRating> ratings)
        {
            _repository.DeleteConspectRatings(ratings);
        }
    }
}
