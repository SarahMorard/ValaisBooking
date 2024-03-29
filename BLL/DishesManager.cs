﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DishesManager : IDishesManager
    {
        public IDishesDB DishesDB { get; }

        public IDishesManager dishesDB => throw new NotImplementedException();

        public DishesManager(IConfiguration configuration)
        {
            DishesDB = new DishesDB(configuration);
        }

        public List<Dishes> GetDishes()
        {
            return DishesDB.GetDishes();
        }

        public Dishes GetDishId(int id)
        {
            return DishesDB.GetDishId(id);
        }

        public Dishes AddDish(Dishes dish)
        {
            return DishesDB.AddDish(dish);
        }

        public int UpdateDish(Dishes dish)
        {
            return DishesDB.UpdateDish(dish);
        }

        public int DeleteDish(int IdDish)
        {
            return DishesDB.DeleteDish(IdDish);
        }

        public List<Dishes> GetListDishes(int id)
        {
            return DishesDB.GetListDishes(id);
        }
    }
}