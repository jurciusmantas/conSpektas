using conSpektas.Data.Entities;

namespace conSpektas.Data.Repositories.Register
{
    public interface IRegisterRepository
    {
        void AddUser(User user);
    }
}