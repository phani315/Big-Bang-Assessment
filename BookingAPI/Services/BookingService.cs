using BookingAPI.Interfaces;
using BookingAPI.Models;
namespace BookingAPI.Services

{
    public class BookingService
    {

        private readonly IRepo<int, Booking> _bookingRepo;




        public BookingService(IRepo<int, Booking> booking_repo)
        {
   
        _bookingRepo = booking_repo;
        }


        public string  GetBookingStatus(int bookingId)
        {
            string status;
            var bookingstatus = _bookingRepo.GetAll().Where(r => r.BookingId == bookingId).ToList();
            if (bookingstatus.Count > 0)
            {
                status = bookingstatus[0].BookingStatus.ToString();
            }
            else
            {
                status = "Please enter a valid Booking Id";
            }
            if (status != null)
            {
                return status;
            }
            return null;
        }


    }
}
