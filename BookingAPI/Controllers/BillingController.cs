using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BookingAPI.Interfaces;
using BookingAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BillingController : ControllerBase
    {


        private readonly IRepo<int, Billing> _repo;

        public BillingController(IRepo<int, Billing> repo)
        {
            _repo = repo;

        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Billing>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Billing>> GetAll() { 
        {
            var billings = _repo.GetAll();
            if (billings.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(billings);

        }


        [HttpGet]
        [ProducesResponseType(typeof(Billing), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
         ActionResult<Billing> Get(int key)
        {
            Billing billings = _repo.Get(key);
            if (billings != null)
                return Ok(billings);
            return NotFound("Billings are Empty");
        }


        [HttpPost]
         ActionResult<Billing> Post(Billing billing)
        {
            Billing book = _repo.Add(billing);
            return Created("BillingList", book);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Billing), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        ActionResult<Billing> Delete(int id)
        {
            var billing = _repo.Delete(id);
            if (billing != null)
            {
                return Ok(billing);
            }
            return BadRequest("Unable to delete the Billing record");
        }

        [HttpPut]
        [ProducesResponseType(typeof(Billing), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
         ActionResult<Billing> Update(Billing billing)
        {
            var updateBilling = _repo.Update(billing);
            if (updateBilling == null)
            {
                BadRequest("Unable to update Billing details");
            }
            return Ok(updateBilling);
        }





    }




}
}
