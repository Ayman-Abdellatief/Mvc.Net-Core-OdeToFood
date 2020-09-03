using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToFood.core;

namespace OdeToFood.Data
{
   public  interface IRestaurantData
    {
      IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int ID);

        Restaurant Update(Restaurant updateRestaurant);

        int Commit();
        
    }


    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ID=1,Name ="Scott's Pizza",Location="Cairo",cuisine=CuisineType.Italian},
                new Restaurant{ID=2,Name ="Cinmon Club",Location="London",cuisine=CuisineType.Indian},
                new Restaurant{ID=3,Name ="La Costa",Location="Cairo",cuisine=CuisineType.Mexican}
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int ID)
        {
            return restaurants.SingleOrDefault(r => r.ID == ID);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var Restaurant = restaurants.SingleOrDefault(r => r.ID == updateRestaurant.ID);
            if(Restaurant != null)
            {
                Restaurant.Name = updateRestaurant.Name;
                Restaurant.Location = updateRestaurant.Location;
                Restaurant.cuisine = updateRestaurant.cuisine;
            }
            return Restaurant;
        }
    }
}
