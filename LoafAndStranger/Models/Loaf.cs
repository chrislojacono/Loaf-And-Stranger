﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoafAndStranger.Models
{
    //Models are for storing pieces of information
    public class Loaf
    {
        public LoafSize Size { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int WeightInOunces  { get; set; }
        public bool Sliced { get; set; }


    }
    //as long as it isnt used anywhere else this can be in the same file
    public enum LoafSize
    {
        Small,
        Medium,
        Large,
    }
}