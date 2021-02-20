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

        [HttpGet]
        public IActionResult GetAllLoaves()
        {
            return Ok(_repo.GetAll());

        }

        [HttpPost]
        public IActionResult AddALoaf(Loaf loaf)
        {
            _repo.AddLoaf(loaf);
            return Created($"api/Loaves/{loaf.Id}", loaf);
        }
    }
}
