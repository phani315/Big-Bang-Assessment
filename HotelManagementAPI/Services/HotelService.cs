using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.Services
{
    public class HotelService
    {

        private readonly IRepo<int, Hotel> _hotelrepo;
        private readonly IRepo<int, Room> _roomRepo;




        public HotelService(IRepo<int, Hotel> hotel_repo, IRepo<int, Room> roomrepo)
        {
            _hotelrepo = hotel_repo;
            _roomRepo = roomrepo;
        }




        public ICollection<Hotel>GetHotelsByLocation(string location)
        {
            var hotels = _hotelrepo.GetAll().Where(c => c.Location == location);


            return hotels.ToList();

        }

        public ICollection<Hotel> GetHotelsByPrice(int min, int max)
        {
            var rooms = _roomRepo.GetAll().Where(r => r.RoomPrice >= min && r.RoomPrice <= max).ToList();
            List<Hotel> hotels = new List<Hotel>();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomPrice >= min && rooms[i].RoomPrice <= max)
                {
                    hotels.Add(_hotelrepo.Get(rooms[i].HotelId));
                }
            }
            if (hotels != null)
            {
                return hotels;
            }
            return null;
        }

        public ICollection<Hotel> GetHotelsByAmenity(string amenity)
        {
            var hotels = _hotelrepo.GetAll().ToList();
            List<Hotel> hotelswithAmenity = new List<Hotel>();
            for (int i = 0; i < hotels.Count; i++)
            {
                string[] amenitieslist = hotels[i].Amenities.Split(',');
                if (amenitieslist.Contains(amenity))
                {
                    hotelswithAmenity.Add(_hotelrepo.Get(hotels[i].Id));
                }
            }
            if (hotels != null)
            {
                return hotels;
            }
            return null;
        }

        public int CountOfRoomsAvailable (string hotelname)
        {
            int count = 0;
            var hotels = _hotelrepo.GetAll();

            List<Hotel> hotel = _hotelrepo.GetAll().Where(c => c.Name == hotelname).ToList();
            if (hotel.Count>=1)
            {
                int hotelid = hotel[0].Id;
                var rooms = _roomRepo.GetAll().Where(r => r.Status == "not booked" && r.HotelId == hotelid).ToList();
                count = rooms.Count;

            }
            
            return count;
        }
        public ICollection<Hotel> SortByRating()
        {
            var hotels = _hotelrepo.GetAll().ToList();
            List<Hotel> sortbyrating = new List<Hotel>();
            sortbyrating = (List<Hotel>)_hotelrepo.GetAll().OrderByDescending(o => o.CustomerRating).ToList();



            if (sortbyrating != null)
            {
                return sortbyrating;
            }
            return null;
        }







    }

}
