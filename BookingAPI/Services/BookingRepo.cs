using System.Diagnostics;
using BookingAPI.Models;
using BookingAPI.Interfaces;

namespace BookingAPI.Services
{
    public class BookingRepo : IRepo<int, Booking>
    {

        private BookingContext _context;

        public BookingRepo(BookingContext context)
        {
            _context = context;
        }


        public Booking Add(Booking item)
        {
            try
            {
                _context.Bookings.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }
        public ICollection<Booking> GetAll()
        {
            var bookings = _context.Bookings.ToList();
            if (bookings.Count > 0)
            {
                return bookings;
            }
            return null;
        }
        public Booking Get(int Id)
        {
            Booking booking = _context.Bookings.SingleOrDefault(p => p.BookingId == Id);
            return booking;
        }

        public Booking Delete(int Id)
        {
            Booking item = Get(Id);
            _context.Bookings.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Booking Update(Booking item)
        {
            Booking booking = _context.Bookings.SingleOrDefault(p => p.BookingId == item.BookingId);
            if (booking != null)
            {
                booking.BookingId = item.BookingId;
                booking.CustomerId= item.CustomerId;
                booking.CheckInDate = item.CheckInDate;
                booking.CheckOutDate = item.CheckOutDate;
                booking.RoomId  = item.RoomId;
                booking.HotelId = item.HotelId;
                booking.BookingStatus = item.BookingStatus;
                _context.SaveChanges();
            }
            return booking;
        }
    }

}
