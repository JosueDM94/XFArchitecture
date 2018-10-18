using System.Threading.Tasks;

namespace XFArchitecture.Core.Contracts.General
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string title, string message, string cancel);
        Task<bool> ShowConfirmAsync(string title, string message, string accept, string cancel);
        Task<string> ShowAlertSheetAsync(string title, string cancel, string destruction, params string[] options);
        void ShowToast(string message, int duration, bool topPosition, string image, string textColor, string backgroundColor);
    }
}
