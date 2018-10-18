using UIKit;
using Foundation;

using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using XFArchitecture.Core.Services;
using XFArchitecture.iOS.Services.Dependency;
using XFArchitecture.Core.Contracts.Dependency;

[assembly: ResolutionGroupName("com.itexico.XFArchitecture")]
namespace XFArchitecture.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Forms.Init();
            Batteries_V2.Init();
            RegisterDependencies();
            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        private void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<IKeyboardService, KeyboardService>();
        }
    }
}