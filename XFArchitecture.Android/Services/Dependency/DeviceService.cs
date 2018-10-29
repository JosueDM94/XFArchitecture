using Xamarin.Forms;
using XFArchitecture.Services.Dependency;
using XFArchitecture.Droid.Services.Dependency;

[assembly: Dependency(typeof(DeviceService))]
namespace XFArchitecture.Droid.Services.Dependency
{
    public class DeviceService : IDeviceService
    {
        public bool SafeArea() => false; //iOS requeriment
    }
}