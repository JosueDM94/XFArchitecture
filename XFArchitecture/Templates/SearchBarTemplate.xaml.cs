using System;

using Xamarin.Forms;

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
        #endregion

        public SearchBarTemplate()
        {
            InitializeComponent();
        }

        void SearchVisible_Clicked(object sender, EventArgs e)
        {
            SearchVisible = !SearchVisible;
        }
    }
}