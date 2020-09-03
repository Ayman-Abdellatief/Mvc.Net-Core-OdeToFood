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
        public IActionResult OnGet(int RestaurantID)
        {
            Cusines = htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantData.GetById(RestaurantID);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Restaurant = restaurantData.Update(Restaurant);
            restaurantData.Commit();
            return Page();

        }
    }
}