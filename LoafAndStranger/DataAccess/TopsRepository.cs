﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoafAndStranger.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace LoafAndStranger.DataAccess
{
    public class TopsRepository
    {

        const string ConnectionString = "Server=localhost;Database=LoafAndStranger;Trusted_Connection=True";
        public List<Top> GetAll()
        {
            using var db = new SqlConnection(ConnectionString);

            var sql = @"select * 
                        from Tops";

            var results = db.Query<Top>(sql).ToList();
            //Name of properties HAVE to be the same as the names in SQL

            return results;
        }
    }
}