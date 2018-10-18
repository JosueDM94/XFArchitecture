using System;

namespace XFArchitecture.Core.Contracts.General
{
    public interface INetworkService
    {
        bool IsConnected { get; }
        void RunAction(Action action);
        T RunFunction<T>(Func<T> func);
        event Action<bool> ConnectivityChanged;
    }
}