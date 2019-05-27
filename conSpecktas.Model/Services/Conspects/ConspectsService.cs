using conSpecktas.Model.Repositories.Conspects;
using conSpektas.Data.DTOs;

namespace conSpecktas.Model.Services.Conspects
{
    public class ConspectsService : IConspectsService
    {
        private readonly IConspectsRepository _repository;
        public ConspectsService(IConspectsRepository repository)
        {
            _repository = repository;
        }

        public conSpektas.Data.Entities.Conspect GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ServerResult UploadConspect(UploadConspectArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}
