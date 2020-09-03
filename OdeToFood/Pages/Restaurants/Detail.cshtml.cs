using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using ToFood.core;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData resturantData;

        public DetailModel(IRestaurantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int RestaurantID)
        {
            Restaurant = resturantData.GetById(RestaurantID);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            
            }
            return Page();
        }
    }
}