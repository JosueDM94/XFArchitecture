using System;
using System.Windows.Input;
using System.Threading.Tasks;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Core.ViewModels.User.Register
{
    public class RegisterViewModel : BaseViewModel
    {
        private int position;
        public int Position
        {
            get { return position; }
            set { SetProperty(ref position, value); }
        }

        public ICommand GoBack { get; private set; }
        public ICommand SearchCommand { get; private set; }

        public RegisterViewModel()
        {
            GoBack = new Command(GoBackPage);
            SearchCommand = new Command<string>(SearchAction);
        }

        public override Task InitializeAsync(object parameters)
        {
            return base.InitializeAsync(parameters);
        }

        public void GoBackPage()
        {
            Navigation.PopModalAsync(false);
        }

        public void SearchAction(string searchText)
        {

        }
    }
}