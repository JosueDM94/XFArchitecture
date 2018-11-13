using Xamarin.Forms;

namespace XFArchitecture.Views.User.Register.Indicator
{
    public partial class RegisterIndicator : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(int), typeof(RegisterIndicator), 0, BindingMode.TwoWay);
        public int Position
        {
            get { return (int)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        #endregion

        public RegisterIndicator()
        {
            InitializeComponent();
        }
    }
}