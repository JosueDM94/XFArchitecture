using System;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using XFArchitecture.Controls;

namespace XFArchitecture.Templates
{
    public partial class SearchBarTemplate : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty SearchVisibleProperty = BindableProperty.Create(nameof(SearchVisible), typeof(bool), typeof(SearchBarTemplate), false, BindingMode.TwoWay);
        public bool SearchVisible
        {
            get { return (bool)GetValue(SearchVisibleProperty); }
            set { SetValue(SearchVisibleProperty, value); }
        }

        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create(nameof(SearchText), typeof(string), typeof(SearchBarTemplate), string.Empty, BindingMode.TwoWay);
        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }
        #endregion

        public SearchBarTemplate()
        {
            InitializeComponent();
        }

        void SearchVisible_Clicked(object sender, EventArgs e)
        {
            SearchText = string.Empty;
            SearchVisible = !SearchVisible;
        }

        void BtnClose_Clicked(object sender, EventArgs e)
        {
            SearchText = string.Empty;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName.Equals(SearchTextProperty.PropertyName) && SearchVisible)
                (BindingContext as NavigationBar)?.SearchCommand?.Execute(SearchText);
        }
    }
}