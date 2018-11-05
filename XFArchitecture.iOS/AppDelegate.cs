using UIKit;
using Foundation;

using SQLitePCL;
using Xamarin.Forms;
using Lottie.Forms.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Platform;

using XFArchitecture.Core.Services;
using XFArchitecture.iOS.Services.Dependency;
using XFArchitecture.Core.Contracts.Dependency;

[assembly: ResolutionGroupName("com.itexico.XFArchitecture")]
namespace XFArchitecture.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Forms.Init();
            Batteries_V2.Init();
            CachedImageRenderer.Init();
            CarouselViewRenderer.Init();
            AnimationViewRenderer.Init();

            RegisterDependencies();
            LoadApplication(new App());
            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        private void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<KeyboardService, IKeyboardService>();
        }
    }
}