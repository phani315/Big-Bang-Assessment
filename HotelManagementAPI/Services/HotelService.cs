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



        //public ICollection<Hotel> GetHotelsBasedonType(string type)
        //{
        //    var rooms = _roomrepo.GetAll().Where(c => c.RoomType == type);
        //    return rooms.ToList();

        //}

       public ICollection<Hotel>GetHotelsByLocation(string location)
        {
            var hotels = _hotelrepo.GetAll().Where(c => c.Location == location);


            return hotels.ToList();

        }

        //public List<Hotel> GetHotelsByPrice(int min, int max)
        //{
        //    if (max < min)
        //        return null;
        //    List<Hotel> hotels = _hotelrepo.GetAll().ToList();
        //    List<Room> rooms = new List<Room>();
        //    rooms = rooms.Where(p => p.RoomPrice >= min && p.RoomPrice <= max).ToList();
        //    for(int i = 0; i < rooms.Count; i++)
        //    {
        //        if (rooms[i].HotelId == hotels)
        //    }
        //    return hotels;
        //}


        //public ICollection<Hotel> GetHotelsByDateOfAvailability(DateTime date)
        //{
        //    var hotels = _hotelrepo.GetAll().Where(c => c.DateOfAvailability == date);


        //    return hotels.ToList();

        //}


    }

}
