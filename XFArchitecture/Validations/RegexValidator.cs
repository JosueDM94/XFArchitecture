using XFArchitecture.Core.Utilities;
using System.Text.RegularExpressions;

namespace XFArchitecture.Validations
{
    public class RegexValidator : BaseValidator
    {
        public RegexValidator()
        {
            Style = ErrorType.Error;
        }

        public override bool Check(object value)
        {
            if (value == null)
                return false;
            if (string.IsNullOrWhiteSpace(Format))
                return false;
            return Regex.IsMatch(value.ToString(), Format);
        }
    }
}