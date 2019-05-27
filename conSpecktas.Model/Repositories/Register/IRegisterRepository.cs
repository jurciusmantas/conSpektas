using conSpektas.Data.Entities;

namespace conSpektas.Model.Repositories.Register
{
    public interface IRegisterRepository
    {
        void AddUser(User user);
    }
}