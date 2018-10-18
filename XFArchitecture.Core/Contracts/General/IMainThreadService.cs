using System;

namespace XFArchitecture.Core.Contracts.General
{
    public interface IMainThreadService
    {
        void RunActionOnUIThread(Action action);
    }
}