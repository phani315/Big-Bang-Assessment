using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using BookingAPI.Models;

using BookingAPI.Interfaces;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class BookingController : ControllerBase
        {
            private readonly IRepo<int, Booking> _repo;

            public BookingController(IRepo<int, Booking> repo)
            {
                _repo = repo;

            }


            [HttpGet]
            [ProducesResponseType(typeof(List<Booking>), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<List<Booking>> FetchAllHotels()
            {
                var bookings = _repo.GetAll();
                if (bookings.Count == 0)
                {
                    return NotFound("No Hotels  available");
                }
                return Ok(bookings);

            }


            [HttpGet]
            [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<Booking> Get(int key)
            {
                Booking bookings = _repo.Get(key);
                if (bookings != null)
                    return Ok(bookings);
                return NotFound("Bookings are Empty");
            }


            [HttpPost]
            public ActionResult<Booking> Post(Booking booking)
            {
                Booking book = _repo.Add(booking);
                return Created("BookingList", book);
            }

            [HttpDelete]
            [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult<Booking> Delete(int id)
            {
                var booking = _repo.Delete(id);
                if (booking != null)
                {
                    return Ok(booking);
                }
                return BadRequest("Unable to delete the booking record");
            }

            [HttpPut]
            [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult<Booking> Update(Booking booking)
            {
                var updateBooking = _repo.Update(booking);
                if (updateBooking == null)
                {
                    BadRequest("Unable to update Booking details");
                }
                return Ok(updateBooking);
            }





        }


    
}
