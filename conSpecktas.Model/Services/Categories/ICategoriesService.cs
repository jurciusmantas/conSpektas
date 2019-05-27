using conSpektas.Data.Entities;

namespace conSpecktas.Model.Services.Categories
{
    public interface ICategoriesService
    {
        Category GetById(int id);
        void Insert(ConspectCategory item);
    }
}