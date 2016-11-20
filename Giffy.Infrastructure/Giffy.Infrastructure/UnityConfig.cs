using Giffy.Service;
using Microsoft.Practices.Unity;

namespace Giffy.Infrastructure
{
    public class UnityConfig
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IGifService, GifService>();
        }
    }
}
