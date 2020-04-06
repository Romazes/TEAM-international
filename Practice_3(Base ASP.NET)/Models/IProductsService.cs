using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3_Base_ASP.NET_.Models
{
    public interface IProductsService
    {
        public List<Product> GetProducts();
        public Product AddProduct(int amount, Product productItem);
        public Product UpdateProduct(int id, Product productItem);
        public int DeleteProduct(int id);
    }
}
