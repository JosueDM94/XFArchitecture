using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

using XFArchitecture.Views.Home;
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
            MainPage = new HomePage();
        }

        void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<IMainThreadService, MainThreadService>();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=1159ec37-eb97-4b1a-9d9e-a6baac2e9f4a; ios=5ccbf9db-cbec-44df-a63c-0939b0f92eab", typeof(Analytics), typeof(Crashes));
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
