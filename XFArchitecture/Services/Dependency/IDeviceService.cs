using System;

namespace XFArchitecture.Services.Dependency
{
    public interface IDeviceService
    {
        bool SafeArea();
        bool IsImageResource(string imageName);
    }
}