using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;

namespace LoafAndStranger.Data
{
    public class LoafRepository
    {
        static List<Loaf> _loaves = new List<Loaf>
            {
                new Loaf {Price = 5.50, Size = LoafSize.Medium, Sliced = true, Type = "Rye"},
                new Loaf {Price = 10.50, Size = LoafSize.Small, Sliced = true, Type = "Pumperknickle"}
            };

        public List<Loaf> GetAll()
        {
            return _loaves;
        }

        public void AddLoaf(Loaf loaf)
        {
            _loaves.Add(loaf);
        }
    }
}
