
namespace Micropack.DesignPattern.Samples.ChainOfResponsibility.Chains
{  
    public class SaveToDatabase : StorePurchaseContext
    {
        public SaveToDatabase(StorePurchaseContext next) : base(next)
        {
            
        }

        public override StorePurchaseResponse Execute(StorePurchaseRequest request)
        {
            // contex.SaveChanges();
            return new StorePurchaseResponse { Message = "success..." };
        }
    }
}
