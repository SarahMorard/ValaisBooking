using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    class Order_DishesManager
    {
        public IOrder_DishesDB Order_DishesDB{ get; }

        public Order_DishesManager(IConfiguration configuration)
        {
            Order_DishesDB = new Order_DishesDB(configuration);
        }

        public List<Order_Dishes> GetOrder_Dishes()
        {
            return Order_DishesDB.GetOrder_Dishes();
        }

        public Order_Dishes GetOrder_DishesId(int id)
        {
            return Order_DishesDB.GetOrder_DishesId(id);
        }

        public Order_Dishes AddOrder_Dishes(Order_Dishes hotel)
        {
            return Order_DishesDB.AddOrder_Dishes(hotel);
        }

        public int UpdateOrder_Dishes(Order_Dishes order_Dishes)
        {
            return Order_DishesDB.UpdateOrder_Dishes(order_Dishes);
        }

        public int DeleteOrder_Dishes(int IdOrder_Dishes)
        {
            return Order_DishesDB.DeleteOrder_Dishes(IdOrder_Dishes);
        }
    }
}
