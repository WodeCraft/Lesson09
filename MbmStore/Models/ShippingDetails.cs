using System.ComponentModel.DataAnnotations;

namespace MbmStore.ViewModels
{
    public class ShippingDetails
    {
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(75)]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"\d{4}")]
        public string Zip { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"\S+@\S+\.\S{2,3}")]
        public string Email { get; set; }

        public bool GiftWrap { get; set; }
    }
}