using System;

namespace XFArchitecture.Core.Contracts.General
{
    public interface IErrorService<T>
    {
        void ShowError(T view, string message);
        void RemoveError(T view);
    }
}