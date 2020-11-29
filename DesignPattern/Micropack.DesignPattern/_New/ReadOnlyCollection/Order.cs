using System.Linq;

namespace Micropack.DesignPattern._New.ReadOnlyCollection
{
    public class Order
    {
        //public int CalculatePrice(List<Product> products)
        //{
        //    return products.Sum(x => x.Price);
        //}

        public int CalculatePrice(Products products)
        {
            // سناریوی بازی با لیست محصولات در اینجا پیاده سازی می شود

            return products.Items.Sum(x => x.Price);
        }
    }
}
