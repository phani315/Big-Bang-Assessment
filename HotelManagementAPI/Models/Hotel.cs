using Microsoft.VisualBasic;

namespace HotelManagementAPI.Models
{

    
        public class Hotel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateOnly DateOfAvailability { get; set; }
            public int RoomPrice { get; set; }
            public int NoOfRoomsAvailable { get; set; }

            public string RoomType { get; set; }
            public string Location { get; set; }



        }
    }


