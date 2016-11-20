using System.Resources;
using Xamarin.Forms;
using System.Reflection;

namespace Giffy.Utilities
{
    class ResourceHelper
    {
        private static readonly ResourceManager _resManager;

        static ResourceHelper()
        {
            _resManager = new ResourceManager("Giffy.Resources.Resource", typeof(ResourceHelper).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Gets page title base on page type
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string GetPageTitle(Page page)
        {
            var result = GetString($"{page.GetType().Name}Title");
            return result;
        }

        /// <summary>
        /// Gets string resource
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string GetString(string resourceName)
        {
            var result = _resManager.GetString(resourceName, App.CurrentCulture);
            return result;
        }
    }
}
