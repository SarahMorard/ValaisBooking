using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    class RestaurantManager
    {
        public IRestaurantDB RestaurantsDB{ get; }

        public RestaurantManager(IConfiguration configuration)
        {
            RestaurantsDB = new RestaurantsDB(configuration);
        }

        public List<Restaurants> GetRestaurants()
        {
            return RestaurantsDB.GetRestaurants();
        }

        public Restaurants GetRestaurantsId(int id)
        {
            return RestaurantsDB.GetRestaurantsId(id);
        }

        public Restaurants AddRestaurants(Restaurants restaurant)
        {
            return RestaurantsDB.AddRestaurants(restaurant);
        }

        public int UpdateRestaurants(Restaurants restaurant)
        {
            return RestaurantsDB.UpdateRestaurants(restaurant);
        }

        public int DeleteRestaurant(int IdRestaurant)
        {
            return RestaurantsDB.DeleteRestaurant(IdRestaurant);
        }
    }
}
