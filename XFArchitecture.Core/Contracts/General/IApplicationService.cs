using System;

namespace XFArchitecture.Core.Contracts.General
{
    public interface IApplicationService
    {
        void SaveProperty(string key, object value);
        T GetProperty<T>(string key);
    }
}