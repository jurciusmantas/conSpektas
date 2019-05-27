using conSpecktas.Model.Repositories.Conspects;

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
    }
}
