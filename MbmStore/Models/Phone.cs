namespace MbmStore.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}