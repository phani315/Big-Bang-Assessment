using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                var hotels = _context.Hotels.ToList();
                if (hotels.Count > 0)
                {
                    return hotels;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }
        public Hotel Get(int key)
        {
            try
            {
                Hotel hotel = _context.Hotels.SingleOrDefault(p => p.Id == key);
                return hotel;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }



        public Hotel Delete(int key)
        {
            try
            {
                Hotel item = Get(key);
                _context.Hotels.Remove(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public Hotel Update(Hotel item)
            
        {
            try
            {
                Hotel hotel = _context.Hotels.SingleOrDefault(p => p.Id == item.Id);
                if (hotel != null)
                {
                    hotel.Name = item.Name;
                    hotel.Id = item.Id;
                    hotel.Amenities = hotel.Amenities + item.Amenities;
                    hotel.Location = item.Location;
                    hotel.CustomerRating = item.CustomerRating;
                    _context.SaveChanges();
                }
                return hotel;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

        }
    }

}
