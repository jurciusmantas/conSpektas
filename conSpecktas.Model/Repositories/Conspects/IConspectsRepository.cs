using conSpektas.Data.Entities;

namespace conSpecktas.Model.Repositories.Conspects
{
    public interface IConspectsRepository
    {
        Conspect GetById(int id);
    }
}