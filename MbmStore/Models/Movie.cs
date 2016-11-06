using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{
    [Table("Movie")]
    public class Movie : Product
    {
        // properties
        public string Director { get; set; }

        // constructors
        public Movie() { }

        public Movie(string title, decimal price) : base(title, price)
        {
        }

        public Movie(string title, decimal price, string imageUrl, string director) : base(title, price)
        {
            ImageUrl = imageUrl;
            Director = director;
        }
    }
}