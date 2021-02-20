﻿using Microsoft.AspNetCore.Http;
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
       static List<Loaf> _loaves = new List<Loaf>
            {
            new Loaf {Price = 5.50, Size = LoafSize.Medium, Sliced = true, Type = "Rye"},
            new Loaf {Price = 10.50, Size = LoafSize.Small, Sliced = true, Type = "Pumperknickle"}
            };

        [HttpGet]
        public List<Loaf> GetAllLoaves()
        {
            return _loaves;

        }

        [HttpPost]
        public HttpResponseMessage AddALoaf(Loaf loaf)
        {
            _loaves.Add(loaf);
            return Created("api/Loaves/1", loaf);
        }
    }
}