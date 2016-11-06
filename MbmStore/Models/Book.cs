using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{

    [Table("Book")]
    public class Book : Product
    {
        // properties
        public string Author { get; set; }
        public string Publisher { get; set; }
        public short Published { get; set; }
        public string ISBN { get; set; }

        // constructors
        public Book() { }

        public Book(string author, string title, decimal price, short published)
            : base(title, price)
        {
            Author = author;
            Published = published;
        }


    }
}