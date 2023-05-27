using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementAPI.Models
{

    
        public class Hotel
        {
             [Key]
             public int Id { get; set; }
            
        
            [Required]

            [StringLength(100, MinimumLength = 2)]

            public string Name { get; set; }
            [Range(0, 1000)]
            
            
            
           public string Location { get; set; }
        
        [StringLength(200, MinimumLength = 2)]
        public string Amenities { get; set; }

        [Range(1, 5)]

        public float  CustomerRating { get; set; }




        public ICollection<Room>? Rooms { get; set; }









    }
}


