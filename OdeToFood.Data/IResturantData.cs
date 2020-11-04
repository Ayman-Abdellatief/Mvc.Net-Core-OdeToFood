using System.Collections.Generic;
using System.Text;
using ToFood.core;

namespace OdeToFood.Data
{
    public  interface IRestaurantData
    {
      IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int ID);

        Restaurant Update(Restaurant updateRestaurant);

        Restaurant Add(Restaurant NewRestaurant);

        Restaurant Delete(int id);
        int GetCountRestaurants();
        int Commit();
        

    }
}
