using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
   public class Order_DishesManager: IOrder_DishesManager
    {
        public IOrder_DishesDB Order_DishesDB{ get; }

        IOrder_DishesManager IOrder_DishesManager.Order_DishesDB => throw new NotImplementedException();

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

        public Order_Dishes AddOrder_Dishes(Order_Dishes order_Dishes)
        {
            return Order_DishesDB.AddOrder_Dishes(order_Dishes);
        }

        public int UpdateOrder_Dishes(Order_Dishes order_Dishes)
        {
            return Order_DishesDB.UpdateOrder_Dishes(order_Dishes);
        }

        public int DeleteOrder_Dishes(int IdOrder_Dishes)
        {
            return Order_DishesDB.DeleteOrder_Dishes(IdOrder_Dishes);
        }

        public Order_Dishes AddOrder_Dishes(Login order_dishes)
        {
            throw new NotImplementedException();
        }

        public List<Order_Dishes> GetOD(int id)
        {
            return Order_DishesDB.GetOD(id);
        }

        public bool VerifOrderDishes(int id)
        {
            return Order_DishesDB.VerifOrderDishes(id);
        }

    }
}
