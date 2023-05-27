using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;
using HotelManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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

        [HttpGet]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> Get(int key)
        {
            Room rooms = _repo.Get(key);
            if (rooms != null)
                return Ok(rooms);
            return NotFound("No rooms available");
        }


        [HttpPost]

        public ActionResult<Room> Post(Room room)
        {
            Room prod = _repo.Add(room);
            return Created("RoomListing", prod);
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
            return BadRequest("Unable to delete the room from database");
        }

        [HttpPut]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Room> Update(Room room)
        {
            var updatedroom = _repo.Update(room);
            if (updatedroom == null)
            {
                BadRequest("Unable to update room details");
            }
            return Ok(room);
        }





    }

}
