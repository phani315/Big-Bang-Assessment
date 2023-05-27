using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;
using HotelManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    public class RoomsController : ControllerBase
    {
        private readonly IRepo<int, Room> _repo;

        public RoomsController(IRepo<int, Hotel> repo)
        {
            _repo = (IRepo<int, Room>?)repo;

        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Room>> GetAllRoomsDetails()
        {
            var rooms = _repo.GetAll();
            if (rooms.Count == 0)
            {
                return NotFound("No Rooms are  available in Database");
            }
            return Ok(rooms);

        }




        //[HttpGet]
        //[ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<List<Hotel>> FetchAllHotelsBasedOnCategory(string category)
        //{
        //    var hotels = _hotelservice.GetHotelsBasedonType(category);
        //    if (hotels.Count == 0)
        //    {
        //        return NotFound("No Hotels  available");
        //    }
        //    return Ok(hotels);

        //}



        


     
        [HttpPost]

        public ActionResult<Room> Post(Room room)
        {
            Room prod = _repo.Add(room);
            return Created("HotelListing", prod);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Room> Delete(int id)
        {
            var room = _repo.Delete(id);
            if (room != null)
            {
                return Ok(room);
            }
            return BadRequest("Unable to delete the hotel");
        }

        [HttpPut]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Room> Update(Room room)
        {
            var updatedroom = _repo.Update(room);
            if (updatedroom == null)
            {
                BadRequest("Unable to update hotel details");
            }
            return Ok(room);
        }





    }

}
