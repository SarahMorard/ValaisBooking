using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    class OrdersManager
    {
        public IOrderManager OrderDB { get; }

        public OrdersManager(IConfiguration configuration)
        {
            OrdersDB = new OrdersDB(configuration);
        }

        public List<Orders> GetOrder()
        {
            return OrdersDB.GetHotels();
        }

        public Orders GetOrdersId(int id)
        {
            return OrdersDB.GetOrdersId(id);
        }

        public Orders AddOrders(Orders order)
        {
            return OrdersDB.AddOrders(order);
        }

        public int UpdateOrders(Orders order)
        {
            return OrdersDB.UpdateOrders(order);
        }

        public int DeleteOrders(int IdOrder)
        {
            return OrdersDB.DeleteOrders(IdOrder);
        }
    }
}
