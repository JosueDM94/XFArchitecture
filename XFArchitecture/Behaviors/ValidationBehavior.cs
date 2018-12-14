using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Contracts.Validation;

namespace XFArchitecture.Behaviors
{
    public class ValidationBehavior : Behavior<View>
    {
        #region Bindable Properties
        public static readonly BindableProperty IsGroupProperty = BindableProperty.Create(nameof(IsGroup), typeof(bool?), typeof(ValidationBehavior), null);
        public bool? IsGroup
        {
            get { return (bool?)GetValue(IsGroupProperty); }
            set { SetValue(IsGroupProperty, value); }
        }

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
        private List<ValidationBehavior> validationBehaviors;

        public string PropertyName { get; set; }
        public ValidationBehavior Group { get; set; }
        public ObservableCollection<IValidator> Validators { get; set; }

        public ValidationBehavior()
        {
            Validators = new ObservableCollection<IValidator>();
            validationBehaviors = new List<ValidationBehavior>();
        }

        public bool Validate()
        {
            bool isValid = true;    
            foreach (IValidator validator in Validators)
            {
                bool result = validator.Check(view.GetType().GetProperty(PropertyName).GetValue(view));
                isValid = isValid && result;
                if (!result)
                {
                    ErrorStyle = validator.Style;
                    ErrorMessage = validator.Message;
                    break;
                }
            }

            IsValid = !isValid;
            return isValid;
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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            //if(propertyName == IsValidProperty.PropertyName && IsGroup.HasValue)
            //{
            //    if(IsGroup.Value)                    
            //}                
        }

        public void Add(ValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void Remove(ValidationBehavior validationBehavior)
        {
            validationBehaviors.Remove(validationBehavior);
        }

        public void Update()
        {
            bool isValid = true;
            foreach (ValidationBehavior validationItem in validationBehaviors)
                isValid = isValid && validationItem.Validate();
            IsValid = isValid;
        }
    }
}