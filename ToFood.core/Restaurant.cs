using System;
using System.Collections.Generic;
using System.Text;

namespace ToFood.core
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType cuisine { get; set; }
    }
}
