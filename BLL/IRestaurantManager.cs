using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IRestaurantManager
    {
        IRestaurantManager RestaurantDB { get; }
        List<Restaurants> GetRestaurant();
        Restaurants GetRestaurantId(int id);
        Restaurants AddRestaurant(Restaurants restaurant);
        int UpdateRestaurant(Restaurants restaurant);
        int DeleteRestaurant(int IdRestaurant);
    }
}
