using System.Windows.Input;

using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.ViewModels.User.Register;

namespace XFArchitecture.Core.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand GoToRegisterCommand { get; private set; }

        public LoginViewModel()
        {
            GoToRegisterCommand = new Command(GoToRegister);
        }

        public void GoToRegister()
        {
            Navigation.PushModalAsync(typeof(RegisterViewModel),false);
        }
    }
}