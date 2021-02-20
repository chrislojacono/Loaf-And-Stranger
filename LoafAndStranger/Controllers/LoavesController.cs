using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using System.Net.Http;

namespace LoafAndStranger.Controllers
{
    [Route("api/Loaves")]
    [ApiController]
    public class LoavesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllLoaves()
        {
            return Ok(_loaves);

        }

        [HttpPost]
        public IActionResult AddALoaf(Loaf loaf)
        {
            _loaves.Add(loaf);
            return Created("api/Loaves/1", loaf);
        }
    }
}
