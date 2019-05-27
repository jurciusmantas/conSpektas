using conSpecktas.Model.Repositories.Categories;
using conSpektas.Data.Entities;

namespace conSpecktas.Model.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _repository;

        public CategoriesService(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(ConspectCategory item)
        {
            _repository.Insert(item);
        }
    }
}
