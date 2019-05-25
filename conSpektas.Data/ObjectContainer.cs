using conSpektas.Data.Services.Register;
using SimpleInjector;

namespace conSpektas.Data
{
    public class ObjectContainer
    {
        public static void Initialize(Container container)
        {
            container.Register<IRegisterService, RegisterService>(Lifestyle.Scoped);
        }
    }
}
