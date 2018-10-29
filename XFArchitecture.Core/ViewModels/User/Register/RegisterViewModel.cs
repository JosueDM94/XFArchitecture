using System;
using System.Windows.Input;
using System.Threading.Tasks;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Core.ViewModels.User.Register
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand GoBack { get; private set; }

        public RegisterViewModel()
        {
            GoBack = new Command(GoBackPage);
        }

        public override Task InitializeAsync(object parameters)
        {
            return base.InitializeAsync(parameters);
        }

        public void GoBackPage()
        {
            Navigation.PopModalAsync(false);
        }
    }
}