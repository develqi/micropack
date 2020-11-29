using System;

namespace Micropack.Domain.Abstraction
{
    public class CascadeDeleteException : Exception
    {
        public override string Message => "Cascade delete occurred...!";
    }
}