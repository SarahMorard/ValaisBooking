using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IOrder_DishesDB
    {
        List<Order_Dishes> GetOrder_Dishes();
        Order_Dishes GetOrder_DishesId(int idOrder_Dishes);
        Order_Dishes AddOrder_Dishes(Order_Dishes order_Dishes);
        int UpdateOrder_Dishes(Order_Dishes order_Dishes);
        int DeleteOrder_Dishes(int id);
        List<Order_Dishes> GetOD(int id);
    }
}
