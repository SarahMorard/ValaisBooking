using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class OrdersManager : IOrderManager
    {
        public IOrderDB OrdersDB { get; }

        public IOrderManager OrderDB => throw new NotImplementedException();

        public OrdersManager(IConfiguration configuration)
        {
            OrdersDB = new OrdersDB(configuration);
        }

        public List<Orders> GetOrders()
        {
            return OrdersDB.GetOrders();
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

        public Orders GetOrderByFK(int fk)
        {
            return OrdersDB.GetOrderByFK(fk);
        }

        public List<Orders> GetListOrder(int id)
        {
            return OrdersDB.GetListOrder(id);
        }
    }
}
