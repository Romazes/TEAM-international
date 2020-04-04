using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3_Base_ASP.NET_.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        //public string Category { get; set; }
        [Required] public ProductCategory Category { get; set; }

        public Product(int id, string title, int amount, ProductCategory category)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Category = category;
        }
    }
}
