using System;

namespace Micropack.Domain.Abstraction
{
    public class NoChangesDetectedException : Exception
    {
        public override string Message => "No changes detected...!";
    }
}