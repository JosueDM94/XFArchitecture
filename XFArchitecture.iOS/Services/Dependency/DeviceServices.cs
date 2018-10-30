using UIKit;
using Foundation;

using Xamarin.Forms;
using XFArchitecture.Services.Dependency;
using XFArchitecture.Droid.Services.Dependency;

[assembly: Dependency(typeof(DeviceService))]
namespace XFArchitecture.Droid.Services.Dependency
{
    public class DeviceService : IDeviceService
    {
        public bool SafeArea()
        {
            if (UIScreen.MainScreen.NativeBounds.Height == 2436 && UIScreen.MainScreen.NativeBounds.Width == 1125) // iPhone X and XS
                return true;
            if (UIScreen.MainScreen.NativeBounds.Height == 2688 && UIScreen.MainScreen.NativeBounds.Width == 1242) //iPhone XS Max
                return true;
            if (UIScreen.MainScreen.NativeBounds.Height == 1792 && UIScreen.MainScreen.NativeBounds.Width == 828) //iPhone XR
                return true;
            return false;
        }

        public bool IsImageResource(string imageName)
        {
            var fileExists = NSBundle.MainBundle.PathForResource(imageName,"png");
            if (fileExists != null)
                return true;
            return false;
        }
    }
}