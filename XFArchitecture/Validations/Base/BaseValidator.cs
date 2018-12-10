using Xamarin.Forms;
using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Contracts.Validation;

namespace XFArchitecture.Validations
{
    public abstract class BaseValidator : BindableObject, IValidator
    {
        #region Bindables Properties
        public static readonly BindableProperty ParameterProperty = BindableProperty.Create(nameof(Parameter), typeof(object), typeof(RequiredValidator), null, BindingMode.TwoWay);
        public object Parameter
        {
            get { return GetValue(ParameterProperty); }
            set { SetValue(ParameterProperty, value); }
        }
        #endregion

        public string Format { get; set; }
        public string Message { get; set; }
        public ErrorType Style { get; set; }
        public PriorityType Priority { get; set; }

        public virtual bool Check(object value) => false;
    }
}