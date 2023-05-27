using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;
using System.Diagnostics;

namespace HotelManagementAPI.Services
{
    public class RoomsManageRepo : IRepo<int, Room>
    {

        private HotelManagementContext _context;

        public RoomsManageRepo(HotelManagementContext context)
        {
            _context = context;
        }


        public  Room Add(Room item)
        {
            try
            {
                _context.Rooms.Add(item);
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
        public ICollection<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }
        public Room Get(int key)
        {
            Room room = _context.Rooms.SingleOrDefault(p => p.RoomId == key);
            return room;
        }



        public Room Delete(int key)
        {
            Room item = Get(key);
            _context.Rooms.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Room Update(Room item)
        {
            Room room = _context.Rooms.SingleOrDefault(p => p.RoomId == item.RoomId);
            if (room != null)
            {
                room.RoomId = item.RoomId;
                room.RoomPrice = item.RoomPrice;
                room.RoomType = item.RoomType;
                room.HotelId = item.HotelId;
                _context.SaveChanges();
            }
            return room;
        }
    }

}
