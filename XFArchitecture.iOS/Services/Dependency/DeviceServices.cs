using UIKit;
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
    }
}