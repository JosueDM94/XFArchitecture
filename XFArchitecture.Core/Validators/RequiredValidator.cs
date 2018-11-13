using System;
using XFArchitecture.Core.Contracts.Validation;

namespace XFArchitecture.Core.Validations
{
    public class RequiredValidator : IValidator<string>
    {
        public string Message { get; set; } = "This field is required";

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}