using Acr.UserDialogs;

using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Core.Services.General
{
    public class LoadingService : ILoadingService
    {
        public void Hide()
        {
            UserDialogs.Instance.HideLoading();
        }

        public void Show(string message = Messages.PleaseWait, MaskType mask = MaskType.Black)
        {
            UserDialogs.Instance.ShowLoading(message, mask);
        }
    }
}
