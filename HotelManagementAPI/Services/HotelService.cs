using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.Services
{
    public class HotelService
    {

        private readonly IRepo<int, Hotel> _hotelrepo;

        public HotelService(IRepo<int, Hotel> hotel_repo)
        {
            _hotelrepo = hotel_repo;

        }



        public ICollection<Hotel> GetHotelsBasedonType(string type)
        {
            var hotels = _hotelrepo.GetAll().Where(c => c.RoomType == type);
            return hotels.ToList();

        }

       public ICollection<Hotel>GetHotelsByLocation(string location)
        {
            var hotels = _hotelrepo.GetAll().Where(c => c.Location == location);


            return hotels.ToList();

        }

        public List<Hotel> GetHotelsByPrice(int min, int max)
        {
            if (max < min)
                return null;
            List<Hotel> hotels = _hotelrepo.GetAll().ToList();
            hotels = hotels.Where(p => p.RoomPrice >= min && p.RoomPrice <= max).ToList();
            return hotels;
        }


        public ICollection<Hotel> GetHotelsByDateOfAvailability(DateOnly date)
        {
            var hotels = _hotelrepo.GetAll().Where(c => c.DateOfAvailability == date);


            return hotels.ToList();

        }


    }

}
