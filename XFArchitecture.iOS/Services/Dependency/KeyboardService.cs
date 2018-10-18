using UIKit;

using XFArchitecture.Core.Contracts.Dependency;

namespace XFArchitecture.iOS.Services.Dependency
{
    public class KeyboardService : IKeyboardService
    {
        public void DismissKeyboard() => UIApplication.SharedApplication.InvokeOnMainThread(() =>
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }

            vc.View.EndEditing(true);
        });
    }
}
