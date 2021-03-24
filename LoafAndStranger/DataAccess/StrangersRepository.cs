using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace LoafAndStranger.DataAccess
{
    public class StrangersRepository
    {
        AppDbContext _db;
        public StrangersRepository(AppDbContext db)
        {
            // ConnectionString = config.GetValue<string>("ConnectionStrings:LoafAndStranger");
            _db = db;
        }
        public IEnumerable<Stranger> GetAll()
        {

            //Multi-Mapping with Dapper
            //var sql = @"select * 
            //            from Strangers s
            //             left join Tops t
            //              on s.TopId = t.Id
            //             left join Loaves l
            //              on s.LoafId = l.Id";

            //using var db = new SqlConnection(ConnectionString);

            //var strangers = db.Query<Stranger, Top, Loaf, Stranger>(sql, 
            //(stranger, top, loaf) =>
            //{
            //    stranger.Loaf = loaf;
            //    stranger.Top = top;

            //    return stranger;
            //}, splitOn: "Id");

            var strangers = _db.Strangers
                .Include(s => s.Loaf)
                .Include(s => s.Top);
            return strangers;
        }
    }
}
