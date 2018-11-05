using System.Windows.Input;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using XFArchitecture.Core.Utilities;
using XFArchitecture.Services.Dependency;

namespace XFArchitecture.Controls
{
    public partial class NavigationBar : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty StatusHeightProperty = BindableProperty.Create(nameof(StatusHeight), typeof(double), typeof(NavigationBar), 0d, BindingMode.TwoWay);
        public double StatusHeight
        {
            get { return (double)GetValue(StatusHeightProperty); }
            set { SetValue(StatusHeightProperty, value); }
        }

        public static readonly BindableProperty NavigationBarStyleProperty = BindableProperty.Create(nameof(NavigationBarStyle), typeof(NavigationBarStyle), typeof(NavigationBar), NavigationBarStyle.CustomBar, BindingMode.TwoWay);
        public NavigationBarStyle NavigationBarStyle
        {
            get { return (NavigationBarStyle)GetValue(NavigationBarStyleProperty); }
            set { SetValue(NavigationBarStyleProperty, value); }
        }

        public static readonly BindableProperty LeftCommandProperty = BindableProperty.Create(nameof(LeftCommand), typeof(ICommand), typeof(NavigationBar), null, BindingMode.TwoWay);
        public ICommand LeftCommand
        {
            get { return (ICommand)GetValue(LeftCommandProperty); }
            set { SetValue(LeftCommandProperty, value); }
        }

        public static readonly BindableProperty RightOneCommandProperty = BindableProperty.Create(nameof(RightOneCommand), typeof(ICommand), typeof(NavigationBar), null, BindingMode.TwoWay);
        public ICommand RightOneCommand
        {
            get { return (ICommand)GetValue(RightOneCommandProperty); }
            set { SetValue(RightOneCommandProperty, value); }
        }

        public static readonly BindableProperty RightTwoCommandProperty = BindableProperty.Create(nameof(RightTwoCommand), typeof(ICommand), typeof(NavigationBar), null, BindingMode.TwoWay);
        public ICommand RightTwoCommand
        {
            get { return (ICommand)GetValue(RightTwoCommandProperty); }
            set { SetValue(RightTwoCommandProperty, value); }
        }

        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(NavigationBar), null, BindingMode.TwoWay);
        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        public static readonly BindableProperty StatusBackgroundColorProperty = BindableProperty.Create(nameof(StatusBackgroundColor), typeof(Color), typeof(NavigationBar), Application.Current.Resources["ColorPrimary"], BindingMode.TwoWay);
        public Color StatusBackgroundColor
        {
            get { return (Color)GetValue(StatusBackgroundColorProperty); }
            set { SetValue(StatusBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty BarBackgroundColorProperty = BindableProperty.Create(nameof(BarBackgroundColor), typeof(Color), typeof(NavigationBar), Application.Current.Resources["ColorPrimaryDark"], BindingMode.TwoWay);
        public Color BarBackgroundColor
        {
            get { return (Color)GetValue(BarBackgroundColorProperty); }
            set { SetValue(BarBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LeftIconProperty = BindableProperty.Create(nameof(LeftIcon), typeof(string), typeof(NavigationBar), Application.Current.Resources["Back"], BindingMode.TwoWay);
        public string LeftIcon
        {
            get { return (string)GetValue(LeftIconProperty); }
            set { SetValue(LeftIconProperty, value); }
        }

        public static readonly BindableProperty RightOneIconProperty = BindableProperty.Create(nameof(RightOneIcon), typeof(string), typeof(NavigationBar), string.Empty, BindingMode.TwoWay);
        public string RightOneIcon
        {
            get { return (string)GetValue(RightOneIconProperty); }
            set { SetValue(RightOneIconProperty, value); }
        }

        public static readonly BindableProperty RightTwoIconProperty = BindableProperty.Create(nameof(RightTwoIcon), typeof(string), typeof(NavigationBar), string.Empty, BindingMode.TwoWay);
        public string RightTwoIcon
        {
            get { return (string)GetValue(RightTwoIconProperty); }
            set { SetValue(RightTwoIconProperty, value); }
        }

        public static readonly BindableProperty TitleIconProperty = BindableProperty.Create(nameof(TitleIcon), typeof(string), typeof(NavigationBar), string.Empty, BindingMode.TwoWay);
        public string TitleIcon
        {
            get { return (string)GetValue(TitleIconProperty); }
            set { SetValue(TitleIconProperty, value); }
        }

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(NavigationBar), "XFArchitecture", BindingMode.TwoWay);
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(NavigationBar), Color.White, BindingMode.TwoWay);
        public Color TitleColor
        {
            get { return (Color)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        public static readonly BindableProperty SubtitleTextProperty = BindableProperty.Create(nameof(SubtitleText), typeof(string), typeof(NavigationBar), string.Empty, BindingMode.TwoWay);
        public string SubtitleText
        {
            get { return (string)GetValue(SubtitleTextProperty); }
            set { SetValue(SubtitleTextProperty, value); }
        }

        public static readonly BindableProperty SubtitleColorProperty = BindableProperty.Create(nameof(SubtitleColor), typeof(Color), typeof(NavigationBar), Color.White, BindingMode.TwoWay);
        public Color SubtitleColor
        {
            get { return (Color)GetValue(SubtitleColorProperty); }
            set { SetValue(SubtitleColorProperty, value); }
        }

        public static readonly BindableProperty HasTitleProperty = BindableProperty.Create(nameof(HasTitle), typeof(bool), typeof(NavigationBar), true, BindingMode.TwoWay);
        public bool HasTitle
        {
            get { return (bool)GetValue(HasTitleProperty); }
            set { SetValue(HasTitleProperty, value); }
        }

        public static readonly BindableProperty HasTitleIconProperty = BindableProperty.Create(nameof(HasTitleIcon), typeof(bool), typeof(NavigationBar), false, BindingMode.TwoWay);
        public bool HasTitleIcon
        {
            get { return (bool)GetValue(HasTitleIconProperty); }
            set { SetValue(HasTitleIconProperty, value); }
        }

        public static readonly BindableProperty HasSubtitleProperty = BindableProperty.Create(nameof(HasSubtitle), typeof(bool), typeof(NavigationBar), false, BindingMode.TwoWay);
        public bool HasSubtitle
        {
            get { return (bool)GetValue(HasSubtitleProperty); }
            set { SetValue(HasSubtitleProperty, value); }
        }

        public static readonly BindableProperty HasBackButtonProperty = BindableProperty.Create(nameof(HasBackButton), typeof(bool), typeof(NavigationBar), true, BindingMode.TwoWay);
        public bool HasBackButton
        {
            get { return (bool)GetValue(HasBackButtonProperty); }
            set { SetValue(HasBackButtonProperty, value); }
        }

        public static readonly BindableProperty HasRightButtonsProperty = BindableProperty.Create(nameof(HasRightButtons), typeof(RightButtons), typeof(NavigationBar), RightButtons.None, BindingMode.TwoWay);
        public RightButtons HasRightButtons
        {
            get { return (RightButtons)GetValue(HasRightButtonsProperty); }
            set { SetValue(HasRightButtonsProperty, value); }
        }

        public static readonly BindableProperty HasShadowProperty = BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(NavigationBar), true, BindingMode.TwoWay);
        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }
        #endregion

        public NavigationBar()
        {
            InitializeComponent();
            InitializeElements();
        }

        private void InitializeElements()
        {
            SetStatusHeight();
        }

        private void SetStatusHeight()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    StatusHeight = DependencyService.Get<IDeviceService>().SafeArea() ? 40 : 20;
                    break;
                default:
                    StatusHeight = 0;
                    break;
            }
        }
    }
}