using System;
using System.Threading.Tasks;

namespace XFArchitecture.Core.Contracts.General
{
    public interface INavigationService
    {
        Task RootNavigation(Type viewModel, object parameter = null);
        Task CreateNavigation(Type viewModel, object parameter = null);

        Task PopAsync(bool animated = true);
        Task PopModalAsync(bool animated = true);
        Task PopToRootAsync(bool animated = true);

        Task PushAsync(Type viewModel, bool animated = true);
        Task PushAsync(Type viewModel, object parameter = null, bool animated = true);
        Task PushModalAsync(Type viewModel, bool animated = true);
        Task PushModalAsync(Type viewModel, object parameter = null, bool animated = true);
    }
}