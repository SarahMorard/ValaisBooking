using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantManager:IRestaurantManager
    {
        public IRestaurantDB RestaurantsDB{ get; }

        public IRestaurantManager RestaurantDB => throw new NotImplementedException();

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

        public List<Restaurants> GetRestaurant()
        {
            throw new NotImplementedException();
        }

        public Restaurants GetRestaurantId(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurants AddRestaurant(Restaurants restaurant)
        {
            throw new NotImplementedException();
        }

        public int UpdateRestaurant(Restaurants restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
