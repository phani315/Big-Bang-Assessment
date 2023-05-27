using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace HotelManagementAPI.Models
{
    public class Room
    {
        [Key]
        

        public int RoomId { get; set; }

        public int RoomPrice { get; set; }

        public string Status { get; set; }
        public string RoomType { get; set; }


        public int HotelId { get; set; }




    }
}
