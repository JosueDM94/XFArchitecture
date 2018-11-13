using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Core.Contracts.Validation
{
    public interface IValidator
    {
        ErrorType Style { get; set; }
        string Message { get; set; }
        bool Check(object value);
    }
}