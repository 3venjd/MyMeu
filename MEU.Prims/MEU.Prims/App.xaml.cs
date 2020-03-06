using Prism;
using Prism.Ioc;
using MEU.Prims.ViewModels;
using MEU.Prims.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MEU.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MEU.Prims
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTY1MzQ5QDMxMzcyZTMzMmUzMElySGVaemMzd0ZXcU9naEIzZE9ldTJlMGxNR3RWbDA3ZjJmSkpHUWpCRWs9");
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<NewsPage, NewsPageViewModel>();
            containerRegistry.RegisterForNavigation<VoysPage, VoysPageViewModel>();
            containerRegistry.RegisterForNavigation<VesselsPage, VesselsPageViewModel>();
            containerRegistry.RegisterForNavigation<StatusPage, StatusPageViewModel>();
            containerRegistry.RegisterForNavigation<AlertsPage, AlertsPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutUsPage, AboutUsPageViewModel>();
            containerRegistry.RegisterForNavigation<FullStylePage, FullStylePageViewModel>();
            containerRegistry.RegisterForNavigation<NewsDetailPage, NewsDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<LineUpsDetailPage, LineUpsDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<OfficesPage, OfficesPageViewModel>();
            containerRegistry.RegisterForNavigation<OfficeDetailsPage, OfficeDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<PortsPage, PortsPageViewModel>();
            containerRegistry.RegisterForNavigation<PortsDetailsPage, PortsDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<TerminalsPage, TerminalsPageViewModel>();
            containerRegistry.RegisterForNavigation<VoysDetailsPage, VoysDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<MEUMasterDetailPage, MEUMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<LineUpsGeneral, LineUpsGeneralViewModel>();
            containerRegistry.RegisterForNavigation<RatePage, RatePageViewModel>();
        }
    }
}
