using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace LoafAndStranger.DataAccess
{
    public class TopsRepository
    {

        AppDbContext _db;

        public TopsRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Top> GetAll()
        {
            //  using var db = new SqlConnection(ConnectionString);


            //var strangersSql = "select * from strangers where topid = @id";

            //var tops = db.Query<Top>(topsSql);

            //foreach (var top in tops)
            //{
            //    var relatedStrangers = db.Query<Stranger>(strangersSql, top);
            //    top.Strangers = relatedStrangers.ToList();
            //}

        


            //var topsSql = @"Select * 
            //            From Tops";
            //var strangersSql = "select * from strangers where topid is not null";

            //var tops = db.Query<Top>(topsSql);
            //var strangers = db.Query<Stranger>(strangersSql);

            //foreach (var top in tops)
            //{
            //    top.Strangers = strangers.Where(stranger => stranger.TopId == top.Id).ToList();
            //}




            //var groupedStrangers = strangers.GroupBy(s => s.TopId);

            //foreach (var groupedStranger in groupedStrangers)
            //{
            //    tops.First(tops => tops.Id == groupedStranger.Key).Strangers = groupedStranger.ToList();
            //}
            return _db.Tops.Include(t => t.Strangers).ThenInclude(s => s.Loaf).AsNoTracking();
        }

        public Top Add(int numberOfSeats)
        {

            //using var db = new SqlConnection(ConnectionString);

            //var sql = @"INSERT INTO [dbo].[Tops]([NumberOfSeats])
            //                output inserted.*
            //                VALUES(@numberOfSeats)";
            //var top = db.QuerySingle<Top>(sql, new { numberOfSeats });
            //return top;

            var top = new Top { NumberOfSeats = numberOfSeats };

            _db.Tops.Add(top);

            _db.SaveChanges();

            return top;
        }
    }
}
