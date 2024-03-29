﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrder_DishesManager
    {
        IOrder_DishesManager Order_DishesDB { get; }
        List<Order_Dishes> GetOrder_Dishes();
        Order_Dishes GetOrder_DishesId(int id);
        Order_Dishes AddOrder_Dishes(Order_Dishes order_dishes);
        int UpdateOrder_Dishes(Order_Dishes order_dishes);
        int Count_Order(int id);
        int DeleteOrder_Dishes(int IdOrder_Dishes);
        List<Order_Dishes> GetOD(int id);
        bool VerifOrderDishes(int id);
    }
}
