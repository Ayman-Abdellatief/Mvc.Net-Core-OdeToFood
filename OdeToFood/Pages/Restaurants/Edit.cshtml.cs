using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;
using ToFood.core;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cusines { get; set; }

        public EditModel(IRestaurantData resturantData,
            IHtmlHelper htmlHelper)
        {
            this.restaurantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? RestaurantID)
        {
            Cusines = htmlHelper.GetEnumSelectList<CuisineType>();
            if(RestaurantID.HasValue)
            { 
            Restaurant = restaurantData.GetById(RestaurantID.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cusines = htmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
           
            }

            if(Restaurant.ID >0)
            { 
            Restaurant = restaurantData.Update(Restaurant);
          
            }
            else
            {
                Restaurant = restaurantData.Add(Restaurant);
            }
            restaurantData.Commit();
            TempData["Message"] = "Resturant Saved!";
            return RedirectToPage("./Detail", new { RestaurantID = Restaurant.ID });

        }
    }
}