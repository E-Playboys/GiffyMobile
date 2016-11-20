using Giffy.Droid.Providers;
using Giffy.Providers;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalizationProvider))]
namespace Giffy.Droid.Providers
{
    public class LocalizationProvider : ILocalizationProvider
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
            return new CultureInfo(netLanguage);
        }
    }
}