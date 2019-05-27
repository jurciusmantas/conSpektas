using conSpektas.Data.Entities;

namespace conSpecktas.Model.Repositories.Categories
{
    public interface ICategoriesRepository
    {
        Category GetById(int id);
        void Insert(ConspectCategory item);
    }
}