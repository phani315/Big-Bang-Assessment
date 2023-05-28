using System.Collections.Generic;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Models
{
    public class BookingContext:DbContext
    {


        public BookingContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Booking> Bookings { get; set; }
    }
}
