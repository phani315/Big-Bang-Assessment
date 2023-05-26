using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace HotelManagementAPI.Models
{


        public class HotelManagementContext : DbContext
        {




            public HotelManagementContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Hotel> Hotels { get; set; }
        }
}
