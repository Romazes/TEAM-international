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
            for (int i = 0; i < 3; i++)
            {
                Baskets.Add(new Product(i + 1, $"Tomato {i + 1}", 20 + i,
                    (ProductCategory)new Random().Next(0, Enum.GetNames(typeof(ProductCategory)).Length),
                    (ProductMetricUnits)new Random().Next(0, Enum.GetNames(typeof(ProductMetricUnits)).Length)));
            }
            for (int i = 0; i < 3; i++)
            {
                Baskets.Add(new Product(i + 1, $"Milk {i + 1}", 20 + i,
                    (ProductCategory)new Random().Next(0, Enum.GetNames(typeof(ProductCategory)).Length),
                    (ProductMetricUnits)new Random().Next(0, Enum.GetNames(typeof(ProductMetricUnits)).Length)
                    ));
            }
            for (int i = 0; i < 3; i++)
            {
                Baskets.Add(new Product(i + 1, $"Tasty {i + 1}", 20 + i,
                    (ProductCategory)new Random().Next(0, Enum.GetNames(typeof(ProductCategory)).Length),
                    (ProductMetricUnits)new Random().Next(0, Enum.GetNames(typeof(ProductMetricUnits)).Length)
                    ));
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
        public readonly string MetricUnits;

        public SimpleViewItem(int id, string title, int amount, string category, 
                              string metricUnits)
        {
            Id = id;
            Title = title;
            Amount = amount;
            MetricUnits = metricUnits;
            Category = category;
        }
    }
}
