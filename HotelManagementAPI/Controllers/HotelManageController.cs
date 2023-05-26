using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;
using HotelManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelManageController : ControllerBase
    {
        private readonly IRepo<int, Hotel> _repo;
        private readonly HotelService _hotelservice;

        public HotelManageController(IRepo<int, Hotel> repo, HotelService hotelservice)
        {
            _repo = repo;
            _hotelservice = hotelservice;

        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Hotel>> FetchAllHotels()
        {
            var hotels = _repo.GetAll();
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }



        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Hotel>> FetchAllHotelsBasedOnCategory(string category)
        {
            var hotels = _hotelservice.GetHotelsBasedonType(category);
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }



        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Hotel>> FetchAllHotelsBasedOnLocation(string location)
        {
            var hotels = _hotelservice.GetHotelsByLocation(location);
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Hotel>> FetchHotelsByDateOfAvailability(DateOnly date)
        {
            var hotels = _hotelservice.GetHotelsByDateOfAvailability(date);
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Hotel>> FetchHotelsWithinAPriceRange(int min,int max)
        {
            var hotels = _hotelservice.GetHotelsByPrice( min,  max);
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }





    }

}
