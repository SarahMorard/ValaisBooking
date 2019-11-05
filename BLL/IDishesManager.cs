using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
     public interface IDishesManager
    {
        IDishesManager dishesDB { get; }
        List<Dishes> GetDishes();
        Dishes GetDishId(int id);
        Dishes AddDish(Dishes dish);
        int UpdateDish(Dishes dish);
        int DeleteDish(int IdDish);
    }
}
