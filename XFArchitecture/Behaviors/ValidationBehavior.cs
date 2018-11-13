using System.ComponentModel;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Contracts.Validation;

namespace XFArchitecture.Behaviors
{
    public class ValidationBehavior : Behavior<View>
    {
        #region Bindable Properties
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ValidationBehavior), false);
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ValidationBehavior), string.Empty);
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        public static readonly BindableProperty ErrorStyleProperty = BindableProperty.Create(nameof(ErrorStyle), typeof(ErrorType), typeof(ValidationBehavior), ErrorType.Error);
        public ErrorType ErrorStyle
        {
            get { return (ErrorType)GetValue(ErrorStyleProperty); }
            set { SetValue(ErrorStyleProperty, value); }
        }
        #endregion
        private View view;

        public string PropertyName { get; set; }
        public ValidationGroupBehavior Group { get; set; }
        public ObservableCollection<IValidator> Validators { get; set; }

        public ValidationBehavior()
        {
            Validators = new ObservableCollection<IValidator>();
        }

        public bool Validate()
        {
            bool isValid = true;    
            foreach (var validator in Validators)
            {
                isValid = validator.Check(view.GetType().GetProperty(PropertyName).GetValue(view));
                if (!isValid)
                {
                    ErrorStyle = validator.Style;
                    ErrorMessage = validator.Message;
                    break;
                }
            }
            return IsValid = !isValid;
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            view = bindable as View;
            view.Unfocused += OnUnFocused;
            view.PropertyChanged += OnPropertyChanged;
            if (Group != null)            
                Group.Add(this);
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            view.Unfocused -= OnUnFocused;
            view.PropertyChanged -= OnPropertyChanged;
            if (Group != null)
                Group.Remove(this);
        }

        void OnUnFocused(object sender, FocusEventArgs e)
        {
            Validate();
            if (Group != null)
                Group.Update();
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PropertyName)
                Validate();
        }
    }
}