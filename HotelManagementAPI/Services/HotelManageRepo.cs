using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;
using System.Diagnostics;

namespace HotelManagementAPI.Services
{


    public class HotelManageRepo : IRepo<int, Hotel>
    {

        private HotelManagementContext _context;

        public HotelManageRepo(HotelManagementContext context)
        {
            _context = context;
        }


        public Hotel Add(Hotel item)
        {
            try
            {
                _context.Hotels.Add(item);
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
        public ICollection<Hotel> GetAll()
        {
            return _context.Hotels.ToList();
        }
        public Hotel Get(int key)
        {
            Hotel hotel = _context.Hotels.SingleOrDefault(p => p.Id == key);
            return hotel;
        }



        public Hotel Delete(int key)
        {
            Hotel item = Get(key);
            _context.Hotels.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Hotel Update(Hotel item)
        {
            Hotel hotel = _context.Hotels.SingleOrDefault(p => p.Id == item.Id);
            if (hotel != null)
            {
                hotel.Name = item.Name;
                hotel.Id = item.Id;
                hotel.NoOfRoomsAvailable = item.NoOfRoomsAvailable;
                _context.SaveChanges();
            }
            return hotel;
        }
    }

}
