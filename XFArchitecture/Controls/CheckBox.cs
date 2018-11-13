using System;
using System.Windows.Input;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace XFArchitecture.Controls
{
    public class CheckBox : Image, IDisposable
    {
        #region Bindable Properties
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(nameof(Checked), typeof(bool), typeof(CheckBox), false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);
        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        public static readonly BindableProperty UnCheckedImageProperty = BindableProperty.Create(nameof(UnCheckedImage), typeof(string), typeof(CheckBox), "ic_checkbox_unchecked");
        public string UnCheckedImage
        {
            get { return (string)GetValue(UnCheckedImageProperty); }
            set { SetValue(UnCheckedImageProperty, value); }
        }

        public static readonly BindableProperty CheckedImageProperty = BindableProperty.Create(nameof(CheckedImage), typeof(string), typeof(CheckBox), "ic_checkbox_checked");
        public string CheckedImage
        {
            get { return (string)GetValue(CheckedImageProperty); }
            set { SetValue(CheckedImageProperty, value); }
        }

        public static readonly BindableProperty CheckedCommandProperty = BindableProperty.Create(nameof(CheckedCommand), typeof(ICommand), typeof(CheckBox), null);
        public ICommand CheckedCommand
        {
            get { return (ICommand)GetValue(CheckedCommandProperty); }
            set { SetValue(CheckedCommandProperty, value); }
        }
        #endregion
        private TapGestureRecognizer imageTapGesture;
        public event EventHandler<bool> CheckedChanged;

        public CheckBox()
        {
            InitElements();
            SetProperties();
            AddEventHandlers();
        }

        private void InitElements()
        {
            imageTapGesture = new TapGestureRecognizer();
        }

        private void SetProperties()
        {
            Aspect = Aspect.AspectFit;
            BackgroundColor = Color.Transparent;
            Source = Checked ? CheckedImage : UnCheckedImage;
        }

        private void AddEventHandlers()
        {
            imageTapGesture.Tapped += ImageTapGesture_OnTapped;
            GestureRecognizers.Add(imageTapGesture);
        }

        private void RemoveEventHandlers()
        {
            imageTapGesture.Tapped -= ImageTapGesture_OnTapped;
            GestureRecognizers.Remove(imageTapGesture);
        }

        private void ImageTapGesture_OnTapped(object sender, EventArgs eventArgs)
        {
            if (IsEnabled)
                Checked = !Checked;

            CheckedCommand?.Execute(Checked);
            CheckedChanged?.Invoke(this, Checked);
        }

        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as CheckBox).OnCheckedChanged((bool)newValue);
        }

        public void OnCheckedChanged(bool newValue)
        {
            Checked = newValue;
            Source = newValue ? CheckedImage : UnCheckedImage;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName.Equals(CheckedProperty.PropertyName) || propertyName.Equals(CheckedImageProperty.PropertyName) || propertyName.Equals(UnCheckedImageProperty.PropertyName))
                Source = Checked ? CheckedImage : UnCheckedImage;
        }

        public void Dispose()
        {
            RemoveEventHandlers();
        }
    }
}