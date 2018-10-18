using Android.Views.InputMethods;

using XFArchitecture.Droid.Models;
using XFArchitecture.Core.Contracts.Dependency;

namespace XFArchitecture.Droid.Services.Dependency
{
    public class KeyboardService : IKeyboardService
    {
        public void DismissKeyboard()
        {
            var inputMethodManager = InputMethodManager.FromContext(Android.App.Application.Context);
            inputMethodManager.HideSoftInputFromWindow(AndroidEntity.Activity.Window.DecorView.WindowToken, HideSoftInputFlags.NotAlways);
        }
    }
}
