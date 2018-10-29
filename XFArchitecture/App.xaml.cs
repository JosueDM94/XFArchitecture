using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

using XFArchitecture.Views.Login;
using XFArchitecture.Core.Services;
using XFArchitecture.Services.General;
using XFArchitecture.Core.Contracts.General;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFArchitecture
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeContainer();
                InitializeComponent();
                InitializeNavigation();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        private void InitializeContainer()
        {
            RegisterDependencies();
            ServiceLocator.Instance.Build();
        }

        private void InitializeNavigation()
        {
            MainPage = new LoginPage();
        }

        void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<NavigationService, INavigationService>();
            ServiceLocator.Instance.Register<MainThreadService, IMainThreadService>();
            ServiceLocator.Instance.Register<ApplicationService, IApplicationService>();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=d0a4ca4b-fd36-4d5e-9dfe-fb47e0ec00c0; ios=edaf035c-6ae5-4552-bdc0-1eb159949b73", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}