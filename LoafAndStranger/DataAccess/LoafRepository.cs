using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace LoafAndStranger.DataAccess
{
    public class LoafRepository
    {
        const string ConnectionString = "Server=localhost;Database=LoafAndStranger;Trusted_Connection=True";

        private Loaf MapLoaf(SqlDataReader reader)
        {
            var id = (int)reader["Id"]; //explicit cast (throws exception)
            var size = (LoafSize)reader["Size"];
            var type = reader["Type"] as string; //implicit cast (returns null)
            var price = (decimal)reader["Price"];
            var weightInOunces = (int)reader["WeightInOunces"];
            var sliced = (bool)reader["Sliced"];
            var createdDate = (DateTime)reader["CreatedDate"];

            var loaf = new Loaf
            {
                Id = id,
                Size = size,
                Type = type,
                Price = price,
                WeightInOunces = weightInOunces,
                Sliced = sliced,
            };
            return loaf;

        }

        public List<Loaf> GetAll()
        {

            using var connection = new SqlConnection(ConnectionString);

            var sql = @"select * 
                        from Loaves";

            var results = connection.Query<Loaf>(sql).ToList();
            //Name of properties HAVE to be the same as the names in SQL

            return results;
        }

        public void AddLoaf(Loaf loaf)
        {
            using var db = new SqlConnection(ConnectionString);

            var sql = @"INSERT INTO [dbo].[Loaves]([Size],[Type],[WeightInOunces],[Price],[Sliced])
                                    OUTPUT inserted.Id
                                    VALUES(@Size,@Type,@WeightInOunces,@Price,@Sliced,)";

            var id = db.ExecuteScalar<int>(sql, loaf);



            //ADO.Net way
            //connection.Open();

            //var command = connection.CreateCommand();

            //command.CommandText = @;

            //command.Parameters.AddWithValue("Size", loaf.Size);
            //command.Parameters.AddWithValue("Type", loaf.Type);
            //command.Parameters.AddWithValue("WeightInOunces", loaf.WeightInOunces);
            //command.Parameters.AddWithValue("Price", loaf.Price);
            //command.Parameters.AddWithValue("Sliced", loaf.Sliced);

            //var id = (int)command.ExecuteScalar();

            loaf.Id = id;
        }

        public Loaf Get(int id)
        {

            var sql = @"select *
                        from Loaves
                        Where Id = @Id";

            using var db = new SqlConnection(ConnectionString);

            var loaf = db.QueryFirstOrDefault<Loaf>(sql, new { Id = id });

            return loaf;
        }

        public void Remove(int id)
        {
            using var db = new SqlConnection(ConnectionString);

            var sql = "Delete from Loaves where Id = @id";

            db.Execute(sql, new { id });

        }

        internal void Update(Loaf loaf)
        {
            var sql = @"update Loaves
                        Set Price = @price,
                            Size = @size,
                            WeightInOunces = @weightinounces,
                            Type = @type,
                            Sliced = @sliced,
                            Where Id = @id";
            using var db = new SqlConnection(ConnectionString);
            db.Execute(sql, loaf);
        }
    }
}
