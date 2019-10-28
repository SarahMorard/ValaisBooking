using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class IRestaurantManager
    {
        IRestaurantManager RestaurantDB { get; }
        List<Restaurant> GetRestaurant();
        Restaurant GetRestaurantId(int id);
        Restaurant AddRestaurant(Restaurant restaurant);
        int UpdateRestaurant(Restaurant restaurant);
        int DeleteRestaurant(int IdRestaurant);
    }
}
