using System;

namespace Micropack.DesignPattern.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTimeOffset Birthday { get; set; }
    }
}
