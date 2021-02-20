using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using LoafAndStranger.Data;
using System.Net.Http;

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
            return Created("api/Loaves/1", loaf);
        }
    }
}
