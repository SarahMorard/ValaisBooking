using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IRestaurantDB
    {
        List<Restaurants> GetRestaurants();
        Restaurants GetRestaurantsId(int idRestaurant);
        Restaurants AddRestaurants(Restaurants restaurants);
        int UpdateRestaurants(Restaurants restaurants);
        int DeleteRestaurant(int id);
    }
}
