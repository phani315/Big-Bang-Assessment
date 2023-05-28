using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {

        [Key]
        public int BookingId { get; set; }

        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set;}

        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string BookingStatus { get; set; }
        public ICollection<Billing>? Billings { get; set; }



    }
}
