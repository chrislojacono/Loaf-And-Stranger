using Microsoft.AspNetCore.Mvc;
using LoafAndStranger.Models;
using LoafAndStranger.DataAccess;

namespace LoafAndStranger.Controllers
{
    [Route("api/Loaves")]
    [ApiController]
    public class LoavesController : ControllerBase
    {

        LoafRepository _repo;
        public LoavesController()
        {
            _repo = new LoafRepository();
        }

        // Get to /api/loaves
        [HttpGet]
        public IActionResult GetAllLoaves()
        {
            return Ok(_repo.GetAll());

        }

        //POST to /api/loaves
        [HttpPost]
        public IActionResult AddALoaf(Loaf loaf)
        {
            _repo.AddLoaf(loaf);
            return Created($"api/Loaves/{loaf.Id}", loaf);
        }

        //GET to /api/loaves/{id} -----dynamic

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loaf = _repo.Get(id);

            if (loaf == null)
            {
                return NotFound("This loaf id does not exist.");
            }
            return Ok(loaf);
        }

        //Idempotency -> Idempotent
        //Things that are Idempotent you should be able to do over and over and not change the result
        //PUT and DELETE should be Idempotent
        // /api/loaves/{id}/slice
        [HttpPut("{id}/slice")]
        public IActionResult SliceLoaf(int id)
        {
            var loaf = _repo.Get(id);

            loaf.Sliced = true;

            return NoContent();

        }

        [HttpDelete ("{loafId}")]
        public IActionResult PurchaseLoaf(int loafId)
        {
            _repo.Remove(loafId);

            return Ok();
        }
    }
}
