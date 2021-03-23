using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using Microsoft.Extensions.Configuration;

namespace LoafAndStranger.DataAccess
{
    public class StrangersRepository
    {
        readonly string ConnectionString;
        public StrangersRepository(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("LoafAndStranger");
        }
        public IEnumerable<Stranger> GetAll()
        {
            return new List<Stranger>();
        }
    }
}
