using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giffy.Utilities
{
    public interface IAppService
    {
        INavigationService Navigation { get; }
    }

    public class AppService : IAppService
    {
        public INavigationService Navigation { get; }
        public AppService(INavigationService navigationService)
        {
            Navigation = navigationService;
        }
    }
}
