using System;

namespace XFArchitecture.Core.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException() : base() { }

        public InvalidTokenException(string message) : base(message) { }

        public InvalidTokenException(string message, Exception innerException) : base(message, innerException) { }
    }
}