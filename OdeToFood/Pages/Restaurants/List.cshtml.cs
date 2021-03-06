using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using ToFood.core;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData resturantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

       [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config,IRestaurantData resturantData)
        {
            this.config = config;
            this.resturantData = resturantData;
        }
        public void OnGet()
        {

            Message = config["Message"] ;
            Restaurants = resturantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
