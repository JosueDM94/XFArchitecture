using System;
using System.Linq;
using System.Threading.Tasks;

using Acr.UserDialogs;

using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Extensions;
using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Core.Services.General
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string title, string message, string cancel = Messages.Ok)
        {
            return UserDialogs.Instance.AlertAsync(message, title, cancel);
        }

        public Task<bool> ShowConfirmAsync(string title, string message, string accept = Messages.Yes, string cancel = Messages.No)
        {
            return UserDialogs.Instance.ConfirmAsync(message, title, accept, cancel);
        }

        public async Task<string> ShowAlertSheetAsync(string title, string cancel, string destruction, params string[] options)
        {
            try
            {
                if (options == null)
                {
                    throw new ArgumentNullException(nameof(options));
                }

                if (!options.Any())
                {
                    throw new ArgumentException("No options provided", nameof(options));
                }

                var result = await UserDialogs.Instance.ActionSheetAsync(title, cancel, destruction, null, options);

                return options.Contains(result) ? result : cancel;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void ShowToast(string message, int duration, bool topPosition, string image, string textColor, string backgroundColor)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(duration);
            toastConfig.SetMessageTextColor(textColor.ToColor());
            toastConfig.SetBackgroundColor(backgroundColor.ToColor());
            if (!string.IsNullOrWhiteSpace(image)) toastConfig.SetIcon(image);
            toastConfig.Position = topPosition ? ToastPosition.Top : ToastPosition.Bottom;
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}
