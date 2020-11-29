namespace Micropack.DesignPattern.Samples
{
    public class Purchase
    {
        public Setting Setting { get; set; }

        public Customer Customer { get; set; }

        public decimal PurchaseAmount { get; set; }

        public void UpdateCustomerPoints() => Customer.UpdatePoint(Setting, PurchaseAmount);
    }
}
