using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Contracts.Validation;

namespace XFArchitecture.Core.Validations
{
    public class RequiredValidator : IValidator
    {
        public ErrorType Style { get; set; } = ErrorType.Error;
        public string Message { get; set; } = "This field is required.";

        public bool Check(object value)
        {
            return !string.IsNullOrWhiteSpace(value.ToString());
        }
    }
}