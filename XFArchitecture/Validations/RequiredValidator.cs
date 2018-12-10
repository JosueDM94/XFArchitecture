using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Validations
{
    public class RequiredValidator : BaseValidator
    {
        public RequiredValidator()
        {
            Style = ErrorType.Error;
            Message = "This field is required.";
        }

        public override bool Check(object value)
        {
            if (value == null)
                return false;
            return !string.IsNullOrWhiteSpace(value.ToString());
        }
    }
}