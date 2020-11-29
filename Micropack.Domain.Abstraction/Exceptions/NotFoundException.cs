using System;

namespace Micropack.Domain.Abstraction
{
    public class NotFoundException : Exception
    {
        public override string Message => "Not found object by the unique identity...!";
    }
}