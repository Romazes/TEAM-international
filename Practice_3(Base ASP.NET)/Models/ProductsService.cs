using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3_Base_ASP.NET_.Models
{
    public class ProductsService : IProductsService
    {
        private List<Product> productItems;

        public ProductsService()
        {
            productItems = new List<Product>();
        }

        public List<Product> GetProducts()
        {
            return productItems;
        }

        public Product AddProduct(int amount, Product productItem)
        {
            for (int i = 0; i < amount; i++)
            {
                productItems.Add(new Product(i + 1, $"Tomato {i + 1}", 20 + i,
                    (ProductCategory)new Random().Next(0, Enum.GetNames(typeof(ProductCategory)).Length),
                    (ProductMetricUnits)new Random().Next(0, Enum.GetNames(typeof(ProductMetricUnits)).Length)));
            }
            return productItem;
        }

        public Product UpdateProduct(int id, Product productItem)
        {
            for (var index = productItems.Count - 1; index >= 0; index--)
            {
                if (productItems[index].Id == id)
                {
                    productItems[index] = productItem;
                }
            }
            return productItem;
        }

        public int DeleteProduct(int id)
        {
            for (var index = productItems.Count - 1; index >= 0; index--)
            {
                if (productItems[index].Id == id)
                {
                    productItems.RemoveAt(index);
                }
            }

            return id;
        }
    }
}
