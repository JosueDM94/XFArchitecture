using System;
using System.Reflection;
using System.Globalization;

using Xamarin.Forms;

using XFArchitecture.Core.Services;

namespace XFArchitecture.Services
{
    public class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view)) return;

            var viewType = view.GetType();
            if (viewType.FullName != null)
            {
                var viewName = viewType.FullName.Replace(".Views.", ".Core.ViewModels.").Replace("Page", "View");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName.Replace("XFArchitecture", "XFArchitecture.Core");
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);
                var viewModelType = Type.GetType(viewModelName);
                if (viewModelType == null) return;
                var viewModel = ServiceLocator.Instance.Resolve(viewModelType);
                view.BindingContext = viewModel;
            }
        }
    }
}