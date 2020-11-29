using System;

namespace Micropack.DesignPattern.Samples.ChainOfResponsibility
{
    public class StorePurchaseRequest
    {
        public int PurchaseAmount { get; set; }

        public string Mobile { get; set; }

        public Guid CustomerId { get; set; }

        public Guid TillId { get; set; }

        public Guid BranchId { get; set; }
    }
}
