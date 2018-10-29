using System;
using System.Reflection;
using System.Globalization;
using System.Threading.Tasks;

using Xamarin.Forms;

using XFArchitecture.Core.ViewModels;
using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Services.General
{
    public class NavigationService : INavigationService
    {
        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("View", "Page").Replace("Core.PageModels", "Views").Replace("Model",string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName.Replace(".Core",string.Empty);
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType,object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null) throw new Exception($"Cannot locate page type for {viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            if(parameter !=null) (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
            return page;
        }

        public async Task PopToRootAsync(bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync(animated);
        }

        public async Task RootNavigation(Type viewModel, object parameter = null)
        {
            Application.Current.MainPage = CreatePage(viewModel, parameter);
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

        public async Task PushAsync(Type viewModel,bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreatePage(viewModel, null), animated);
        }

        public async Task PushAsync(Type viewModel, object parameter = null, bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreatePage(viewModel, parameter),animated);
        }

        public async Task PushModalAsync(Type viewModel, bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(CreatePage(viewModel, null), animated);
        }

        public async Task PushModalAsync(Type viewModel, object parameter = null, bool animated = true)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(CreatePage(viewModel, parameter),animated);
        }

        public async Task CreateNavigation(Type viewModel, object parameter = null)
        {
            Application.Current.MainPage = new NavigationPage(CreatePage(viewModel, parameter));
            await Task.FromResult(true);
        }
    }
}