using Giffy.Controls;
using Giffy.Infrastructure;
using Giffy.Providers;
using Giffy.Resources;
using Giffy.Utilities;
using Giffy.Views;
using Plugin.Connectivity;
using Prism.Unity;
using System.Globalization;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Giffy
{
    public partial class App : PrismApplication
    {
        public static CultureInfo CurrentCulture;

        public static bool IsNetworkReachable;

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            SetupCultureInfo();
            // Network status
            IsNetworkReachable = CrossConnectivity.Current.IsConnected;
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                IsNetworkReachable = args.IsConnected;
            };

            NavigationService.NavigateAsync($"{nameof(MainPage)}/{nameof(IconTabItemPage)}/{nameof(SyntheticGIFPage)}");
        }

        protected override void RegisterTypes()
        {
            // need to register these built-in pages to make the navigation works if navigating through these pages
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<TabbedPage>();
            Container.RegisterTypeForNavigation<MasterDetailPage>();

            Container.RegisterTypeForNavigation<IconTabItemPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SyntheticGIFPage>();
            Container.RegisterTypeForNavigation<AdultsGIFPage>();
            Container.RegisterType<IAppService, AppService>();
            UnityConfig.Register(Container);
        }

        private void SetupCultureInfo()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                CurrentCulture = DependencyService.Get<ILocalizationProvider>().GetCurrentCultureInfo();
                Resource.Culture = CurrentCulture;
            }
        }
    }
}
