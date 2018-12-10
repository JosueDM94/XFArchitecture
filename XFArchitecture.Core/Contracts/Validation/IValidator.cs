using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Core.Contracts.Validation
{
    public interface IValidator
    {
        object Parameter { get; set; }
        ErrorType Style { get; set; }
        string Message { get; set; }
        string Format { get; set; }
        PriorityType Priority { get; set; }
        bool Check(object value);
    }
}