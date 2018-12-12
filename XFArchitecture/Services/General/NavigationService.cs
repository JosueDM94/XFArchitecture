using System;
using System.Reflection;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;

using XFArchitecture.Views.Home;
using XFArchitecture.Views.Login;

using XFArchitecture.Core.Services;
using XFArchitecture.Core.ViewModels;
using XFArchitecture.Core.ViewModels.Home;
using XFArchitecture.Core.ViewModels.Login;
using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Services.General
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> mappings;

        public NavigationService()
        {
            mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            
            return mappings[viewModelType];
        }

        private Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null) throw new Exception($"Cannot locate page type for {viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            var viewModel = ServiceLocator.Instance.Resolve(viewModelType);
            if (viewModel != null) page.BindingContext = viewModel;
            if (parameter !=null) (viewModel as BaseViewModel).InitializeAsync(parameter);
            return page;
        }

        void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(HomeViewModel), typeof(HomePage));
            mappings.Add(typeof(LoginViewModel), typeof(LoginPage));            
        }

        public async Task PopToRootAsync(bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync(animated);
        }

        public async Task RootNavigation(Type viewModel, object parameter = null)
        {
            Application.Current.MainPage = CreateAndBindPage(viewModel, parameter);
            await Task.FromResult(true);
        }

        public async Task RootNavigation<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            Application.Current.MainPage = CreateAndBindPage(typeof(TViewModel), parameter);
            await Task.FromResult(true);
        }

        public async Task PopAsync(bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PopAsync(animated);
        }

        public async Task PopModalAsync(bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync(animated);
        }

        public async Task PushAsync<TViewModel>(bool animated = true) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreateAndBindPage(typeof(TViewModel), null), animated);
        }

        public async Task PushAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreateAndBindPage(typeof(TViewModel), parameter), animated);
        }

        public async Task PushAsync(Type viewModel,bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreateAndBindPage(viewModel, null), animated);
        }

        public async Task PushAsync(Type viewModel, object parameter = null, bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreateAndBindPage(viewModel, parameter),animated);
        }

        public async Task PushModalAsync(Type viewModel, bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(CreateAndBindPage(viewModel, null), animated);
        }

        public async Task PushModalAsync(Type viewModel, object parameter = null, bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(CreateAndBindPage(viewModel, parameter),animated);
        }

        public async Task PushModalAsync<TViewModel>(bool animated = true) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(CreateAndBindPage(typeof(TViewModel), null), animated);
        }

        public async Task PushModalAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(CreateAndBindPage(typeof(TViewModel), parameter), animated);
        }

        public async Task CreateNavigation(Type viewModel, object parameter = null)
        {
            Application.Current.MainPage = new NavigationPage(CreateAndBindPage(viewModel, parameter));
            await Task.FromResult(true);
        }

        public async Task CreateNavigation<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            Application.Current.MainPage = new NavigationPage(CreateAndBindPage(typeof(TViewModel), parameter));
            await Task.FromResult(true);
        }
    }
}