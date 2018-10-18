using System;

using Xamarin.Forms;

using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Services.General
{
    public class MainThreadService : IMainThreadService
    {
        public void RunActionOnUIThread(Action action)
        {
            Device.BeginInvokeOnMainThread(action);
        }
    }
}