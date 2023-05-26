using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.Services
{
 

        public class HotelManageRepo : IRepo<int, Hotel>
        {

            private HotelManagementContext _context;

            public HotelManageRepo(HotelManagementContext context)
            {
                _context = context;
            }

            public ICollection<Hotel> GetAll()
            {
                return _context.Hotels.ToList();
            }
            public Hotel Get(int id)
            {
                Hotel hotel = _context.Hotels.SingleOrDefault(p => p.Id == id);
                return hotel;
            }


        }

   
}
