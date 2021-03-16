using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using Microsoft.Data.SqlClient;

namespace LoafAndStranger.DataAccess
{
    public class LoafRepository
    {
        static List<Loaf> _loaves = new List<Loaf>
            {
                new Loaf {Id= 1, Price = 5.50, Size = LoafSize.Medium, Sliced = true, Type = "Rye", WeightInOunces=6},
                new Loaf {Id = 2, Price = 10.50, Size = LoafSize.Small, Sliced = true, Type = "Pumperknickle", WeightInOunces=15}
            };

        public List<Loaf> GetAll()
        {

            var loaves = new List<Loaf>();
            //create a connection
            using var connection = new SqlConnection("Server=localhost;Database=LoafAndStranger;Trusted_Connection=True");
            //open the connection
            connection.Open();

            //create a command
            var command = connection.CreateCommand();

            //Telling the command what you want to do
            command.CommandText = @"select * 
                                    from Loaves";

            //send the command to sql server or EXECUTE command
            var reader = command.ExecuteReader();

            // loop over results
            while (reader.Read()) //reader.Read pulls one row at a time from the db
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
                loaves.Add(loaf);
            }
            
            return loaves;
        }

        public void AddLoaf(Loaf loaf)
        {
            var biggestExistingId = _loaves.Max(bread => bread.Id);
            loaf.Id = biggestExistingId + 1;
            _loaves.Add(loaf);
        }

        public Loaf Get(int id)
        {

            var sql = @"select *
                        from Loaves
                        Where Id = 1";

            //create a connection
            using var connection = new SqlConnection("Server=localhost;Database=LoafAndStranger;Trusted_Connection=True");
            //open the connection
            connection.Open();

            //create a command
            var command = connection.CreateCommand();

            command.CommandText = sql;

            //send the command to sql server or EXECUTE command
            var reader = command.ExecuteReader();

            //var loaf = _loaves.FirstOrDefault(bread => bread.Id == id);
            //return loaf;
        }

        public void Remove(int id)
        {
            var loafToRemove = Get(id);
            _loaves.Remove(loafToRemove);
        }
    }
}
