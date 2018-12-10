using System.Windows.Input;

using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.ViewModels.User.Register;

namespace XFArchitecture.Core.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        #region Bindables Properties
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand GoToRegisterCommand { get; private set; }
        #endregion

        public LoginViewModel()
        {
            LoginCommand = new Command(LoginAction);
            GoToRegisterCommand = new Command(GoToRegister);
        }

        public void GoToRegister()
        {
            Navigation.PushModalAsync(typeof(RegisterViewModel),false);
        }

        public void LoginAction()
        {
        }
    }
}