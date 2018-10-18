using Acr.UserDialogs;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Core.Contracts.General
{
    public interface ILoadingService
    {
        void Hide();
        void Show(string message = Messages.PleaseWait, MaskType mask = MaskType.Black);
    }
}
