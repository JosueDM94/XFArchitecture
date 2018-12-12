using System;
using System.Threading.Tasks;

using XFArchitecture.Core.ViewModels;

namespace XFArchitecture.Core.Contracts.General
{
    public interface INavigationService
    {
        Task RootNavigation(Type viewModel, object parameter = null);
        Task CreateNavigation(Type viewModel, object parameter = null);
        Task RootNavigation<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;
        Task CreateNavigation<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;

        Task PopAsync(bool animated = true);
        Task PopModalAsync(bool animated = true);
        Task PopToRootAsync(bool animated = true);

        Task PushAsync(Type viewModel, bool animated = true);
        Task PushAsync(Type viewModel, object parameter = null, bool animated = true);
        Task PushAsync<TViewModel>(bool animated = true) where TViewModel : BaseViewModel;
        Task PushAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel;

        Task PushModalAsync(Type viewModel, bool animated = true);
        Task PushModalAsync(Type viewModel, object parameter = null, bool animated = true);
        Task PushModalAsync<TViewModel>(bool animated = true) where TViewModel : BaseViewModel;
        Task PushModalAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel;
    }
}