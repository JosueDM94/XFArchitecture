using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using XFArchitecture.Core.Models;
using XFArchitecture.Core.Services;
using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Contracts.General;
using XFArchitecture.Core.Contracts.Database;
using XFArchitecture.Core.Contracts.Repository;

namespace XFArchitecture.Core.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IDialogService Dialog { get; set; }
        protected ILoadingService Loading { get; set; }
        protected TaskFactory TaskFactory { get; set; }
        protected INetworkService Network { get; set; }
        protected IDatabaseService Database { get; set; }
        protected IRepositoryService Repository { get; set; }
        protected IMainThreadService MainThread { get; set; }

        public BaseViewModel()
        {
            TaskFactory = new TaskFactory();
            Dialog = ServiceLocator.Instance.Resolve<IDialogService>();
            Loading = ServiceLocator.Instance.Resolve<ILoadingService>();
            Network = ServiceLocator.Instance.Resolve<INetworkService>();
            Database = ServiceLocator.Instance.Resolve<IDatabaseService>();
            Repository = ServiceLocator.Instance.Resolve<IRepositoryService>();
            MainThread = ServiceLocator.Instance.Resolve<IMainThreadService>();
        }

        protected bool CheckInternet()
        {
            if (!Network.IsConnected)
            {
                ShowAlert(Messages.ErrorTitle, Messages.NoInternetError);
                return false;
            }
            return true;
        }

        protected bool CheckInternetWithouAlert()
        {
            return !Network.IsConnected;
        }

        protected bool CheckErrors(BaseEntity baseEntity, string title = Messages.ErrorTitle)
        {
            if (baseEntity == null)
            {
                ShowAlert(title, Messages.GeneralErrorMessage);
                return true;
            }

            if (!string.IsNullOrEmpty(baseEntity.Message))
            {
                ShowAlert(title, baseEntity.Message);
                return true;
            }

            return false;
        }

        protected async void ShowAlert(string title, string message, string cancel = Messages.Ok)
        {
            await Dialog.ShowAlertAsync(title, message, cancel);
        }

        protected async Task<bool> ShowAlertConfirm(string title, string message, string accept = Messages.Yes, string cancel = Messages.No)
        {
            return await Dialog.ShowConfirmAsync(title, message, accept, cancel);
        }

        protected async Task<string> ShowAlertSheet(string title, string cancel, string destruction, params string[] options)
        {
            return await Dialog.ShowAlertSheetAsync(title, cancel, destruction, options);
        }

        protected void ShowToast(string message, int duration = 3000, bool topPosition = false, string image = null, string textColor = "#FFFFFF", string backgroundColor = "#D3D3D3")
        {
            Dialog.ShowToast(message, duration, topPosition, image, textColor, backgroundColor);
        }

        protected void DoAction(Action action)
        {
            MainThread.RunActionOnUIThread(action);
        }

        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            //if value didn't change
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
