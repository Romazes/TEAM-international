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
            for (int i = 0; i < 1; i++)
            {
                Baskets.Add(Seed("Tomato", 200));
                Baskets.Add(Seed("Potato", 200));
                Baskets.Add(Seed("Apple", 200));
                Baskets.Add(Seed("Milk", 200));
                Baskets.Add(Seed("Crab", 200));
                Baskets.Add(Seed("Meat", 200));
            }
        }

        static Product Seed(string name, double amount)
        {
            return new Product (new Random().Next(0, 100), $"{name}", amount,
                    (ProductCategory)new Random().Next(0, Enum.GetNames(typeof(ProductCategory)).Length),
                    (ProductMetricUnits)new Random().Next(0, Enum.GetNames(typeof(ProductMetricUnits)).Length));
        }
    }

    public class SimpleViewModel
    {
        public readonly List<SimpleViewItem> ViewProducts;
        public SimpleViewModel(List<SimpleViewItem> viewProducts) => ViewProducts = viewProducts;
    }

    public class SimpleViewItem
    {
        public readonly int Id;
        public readonly string Title;
        public readonly double Amount;
        public readonly string Category;
        public readonly string MetricUnits;

        public SimpleViewItem(int id, string title, double amount, string category, 
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
