using System;
using System.Collections.Generic;
using System.Text;
using DTO;


namespace DAL
{
    public interface IDishesDB
    {
        List<Dishes> GetDishes();
        Dishes GetDishId(int idDishes);
        Dishes AddDish(Dishes dishes);
        int UpdateDish(Dishes dishes);
        int DeleteDish(int id);
    }
}
