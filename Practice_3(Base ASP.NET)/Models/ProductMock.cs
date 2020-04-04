using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3_Base_ASP.NET_.Models
{
    public static class ProductMock
    {
        public static readonly List<Product> Baskets = new List<Product>();

        static ProductMock()
        {
            for (int i = 0; i < 15; i++)
            {
                Baskets.Add(new Product(i + 1, $"Tomato {i + 1}", 20 + i, 
                    (ProductCategory) new Random().Next(0, Enum.GetNames(typeof(ProductCategory)).Length)));
            }
        }
    }

    //public class Basket
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Amount { get; set; }
    //    public string  Category { get; set; }
    //}

    public class SimpleViewModel
    {
        public readonly List<SimpleViewItem> ViewProducts;
        public SimpleViewModel(List<SimpleViewItem> viewProducts) => ViewProducts = viewProducts;
    }

    public class SimpleViewItem
    {
        public readonly int Id;
        public readonly string Title;
        public readonly int Amount;
        public readonly string Category;

        public SimpleViewItem(int id, string title, int amount, string category)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Category = category;
        }
    }
}
