
namespace Micropack.DesignPattern._New.ReadOnlyCollection
{
    public class Customer
    {
        // این اینترفیس نباید اینجا تزریق شود. چون کاربر نباید به متد 
        // GetProducts()
        // دسترسی داشته باشد
        public Customer(IProductRepository productRepository)
        {
            //var products = productRepository.GetProducts(); // کاربر نباید به این متد دسترسی داشته باشد

            var activeProducts = Products.Create(productRepository).GetActiveProducts();

            new Order().CalculatePrice(activeProducts); // این متد، لیست ای از محصولات را به عنوان ورودی دریافت میکند
        }

        public Customer(Products products)
        {
            var activeProducts = products.GetActiveProducts();

            new Order().CalculatePrice(products); // این متد، لیست ای از محصولات را به عنوان ورودی دریافت میکند
        }
    }
}