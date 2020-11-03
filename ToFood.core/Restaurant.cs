using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToFood.core
{
    public class Restaurant
    {
        public int ID { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Location { get; set; }
      
        public CuisineType cuisine { get; set; }
    }
}
