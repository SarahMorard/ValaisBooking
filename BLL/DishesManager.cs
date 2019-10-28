using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
   public class DishesManager
    {
        public IDishesDB DishesDB{ get; }

        public DishesManager (IConfiguration configuration)
        {
            DishesDB = new DishesDB(configuration);
        }

        public List<Dishes> GetHotels()
        {
            return DishesDB.GetDish();
        }

        public Dishes GetHotelId(int id)
        {
            return DishesDB.GetDishId(id);
        }

        public Dishes AddHotel(Dishes dish)
        {
            return DishesDB.AddDish(dish);
        }

        public int UpdateHotel(Dishes dish)
        {
            return DishesDB.UpdateDish(dish);
        }

        public int DeleteHotel(int IdDish)
        {
            return DishesDB.DeleteDish(IdDish);
        }
    }
}
