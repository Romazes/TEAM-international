using System.ComponentModel.DataAnnotations;

namespace Practice_3_Base_ASP.NET_.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, enter the Title of Product.")]
        public string Title { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Please, enter only positive Number.")]
        public double Amount { get; set; }
        [Required(ErrorMessage ="Please, choose Metric Units for Product.")]
        public ProductMetricUnits MetricUnit { get; set; }
        [Required(ErrorMessage = "Please, choose Category for Product.")]
        public ProductCategory Category { get; set; }

        public Product()
        {}

        public Product(int id, string title, double amount, ProductCategory category)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Category = category;
        }

        public Product(int id, string title, double amount, ProductCategory category,
                       ProductMetricUnits metricUnit) : this(id, title, amount, category)
        {
            MetricUnit = metricUnit;
        }
    }
}
