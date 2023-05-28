using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Billing
    {
        [Key]
        public int BillingId { get; set; }

        [Required]
        public int BookingId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public int TotalPrice { get; set; }

        public string PaymentStatus { get; set; }


    }

}
