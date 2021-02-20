using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;

namespace LoafAndStranger.Controllers
{
    [Route("api/Loaves")]
    [ApiController]
    public class LoavesController : ControllerBase
    {
        [HttpGet]
        public List<Loaf> GetAllLoaves()
        {
            return new List<Loaf>
            {
            new Loaf {Price = 5.50, Size = LoafSize.Medium, Sliced = true, Type = "Rye"},
            new Loaf {Price = 10.50, Size = LoafSize.Small, Sliced = true, Type = "Pumperknickle"}
            };

        }
    }
}
