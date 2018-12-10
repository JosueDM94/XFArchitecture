using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Validations
{
    public class CompareValidator : BaseValidator
    {
        public CompareValidator()
        {
            Style = ErrorType.Error;
        }

        public override bool Check(object value)
        {
            if (value == null)
                return false;
            if (Parameter == null)
                return false;
            return value.ToString().Equals(Parameter.ToString());
        }
    }
}