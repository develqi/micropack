using System;

namespace Micropack.Domain.Abstraction
{
    public class BusinessLogicException : Exception
    {
        private readonly string _message;

        public BusinessLogicException(string message) : base(message)
        {
            _message = message;
        }

        public override string Message => _message;
    }
}