using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{

    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }


        // constructor
        public Product() { }

        // constructor
        public Product(string title, decimal price)
        {
            Title = title;
            Price = price;
        }
    }
}