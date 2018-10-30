using Xamarin.Forms;

using XFArchitecture.Droid.Models;
using XFArchitecture.Services.Dependency;
using XFArchitecture.Droid.Services.Dependency;

[assembly: Dependency(typeof(DeviceService))]
namespace XFArchitecture.Droid.Services.Dependency
{
    public class DeviceService : IDeviceService
    {
        public bool SafeArea() => false; //iOS requeriment

        public bool IsImageResource(string imageName)
        {
            int fileExists = AndroidEntity.Context.Resources.GetIdentifier(imageName,"drawable", AndroidEntity.Context.PackageName);
            if (fileExists != 0)
                return true;
            return false;
        }
    }
}