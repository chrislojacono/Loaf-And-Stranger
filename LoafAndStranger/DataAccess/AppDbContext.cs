using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoafAndStranger.Models;

namespace LoafAndStranger.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Loaf> Loaves { get; set; }
        public DbSet<Top> Tops { get; set; }
        public DbSet<Stranger> Strangers { get; set; }
    }
}