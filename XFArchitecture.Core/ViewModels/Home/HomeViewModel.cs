using System;
using System.Windows.Input;
using System.Threading.Tasks;

using XFArchitecture.Core.Models;
using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Contracts.Dependency;

namespace XFArchitecture.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand AddUser { get; private set; }
        public ICommand DeleteUser { get; private set; }
        public ICommand UpdateUser { get; private set; }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value, onChanged: DismissKeyboard); }
        }

        private IKeyboardService Keyboard;

        public HomeViewModel(IKeyboardService keyboardService)
        {
            Keyboard = keyboardService;
            Title = "Using Dependency Injection";
            AddUser = new Command(AddUserCommand);
            DeleteUser = new Command(DeleteUserCommand);
            UpdateUser = new Command(UpdateUserCommand);
        }

        public void DismissKeyboard()
        {
            if (Name.Length > 5) 
                Keyboard.DismissKeyboard();
        }

        public async void AddUserCommand()
        {
            Loading.Show();
            await Database.InsertUser(new User() { Name = Name });
            var users = await Database.Select();
            ShowToast(users.Count.ToString());
            Loading.Hide();
        }

        public async void DeleteUserCommand()
        {
            await Database.DeleteUser(new User() { Id=Id, Name = Name });
            var users = await Database.Select();
            ShowToast(users.Count.ToString());
        }

        public async void UpdateUserCommand()
        {
            await Database.UpdateUser(new User() { Id = Id, Name = Name });
            var users = await Database.Select();
            ShowToast(users.Count.ToString());
        }
    }
}