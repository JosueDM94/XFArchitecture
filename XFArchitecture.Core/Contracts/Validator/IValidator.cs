namespace XFArchitecture.Core.Contracts.Validation
{
    public interface IValidator<T>
    {
        string Message { get; set; }
        bool Check(T value);
    }
}