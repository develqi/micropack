using System.Linq;
using System.Collections.Generic;

namespace Micropack.DesignPattern._New.ReadOnlyCollection
{
    public class Products
    {
        private readonly IProductRepository _productRepository;
        private readonly IReadOnlyList<Product> _products; // لیست محصولات کجا مقداردهی می شوند؟

        public IEnumerable<Product> Items { get; set; }

        public Products(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            //_products = _productRepository.GetProducts(); // آیا لیست محصولات در اینجا مقداردهی می شوند؟
        }

        public static Products Create(IProductRepository productRepository)
        {
            return new Products(productRepository);
        }

        public Products GetActiveProducts()
        {
            return new Products(_productRepository) { Items = _products.Where(x => x.IsActive) };
        }
    }
}
