using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementAPI.Models
{
    public class Room
    {

        public int RoomId { get; set; }

        public int RoomPrice { get; set; }

       
        public int HotelId { get; set; }

        public string RoomType { get; set; }

        public ICollection<Room>? Rooms { get; set; }

    }
}
