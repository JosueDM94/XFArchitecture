using System;

using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

using XFArchitecture.Core.Exceptions;
using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Core.Services.General
{
    public class NetworkService : INetworkService, IDisposable
    {
        public event Action<bool> ConnectivityChanged;

        public NetworkService()
        {
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        public bool IsConnected
        {
            get
            {
                return CrossConnectivity.Current.IsConnected;
            }
        }

        public void RunAction(Action action)
        {
            if (IsConnected)
                action?.Invoke();
            else
                throw new NotConnectedException();
        }

        public T RunFunction<T>(Func<T> func)
        {
            if (IsConnected)
                return func.Invoke();
            else
                throw new NotConnectedException();
        }

        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(e.IsConnected);
        }

        public void Dispose()
        {
            CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
        }
    }
}