using System.Collections.Generic;

namespace Micropack.DesignPattern._New.ReadOnlyCollection
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
