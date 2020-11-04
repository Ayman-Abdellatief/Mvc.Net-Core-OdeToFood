using System.Collections.Generic;
using ToFood.core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlResturantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlResturantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant NewRestaurant)
        {
            db.Add(NewRestaurant);
            return NewRestaurant;
        }

        public int Commit()
        {
          return  db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var resturant = GetById(id);
            if (resturant != null)
            {
                db.Restaurants.Remove(resturant);
            }

            return resturant;
        }

        public Restaurant GetById(int ID)
        {
            return db.Restaurants.Find(ID);
        }

        public int GetCountRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity =db.Restaurants.Attach(updateRestaurant);

            entity.State = EntityState.Modified;
            return updateRestaurant;
        }
    }
}
