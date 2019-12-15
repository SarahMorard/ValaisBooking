using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrderManager
    {
        IOrderManager OrderDB { get; }
        List<Orders> GetOrders();
        Orders GetOrdersId(int id);
        Orders AddOrders(Orders order);
        int UpdateOrders(Orders order);
        int DeleteOrders(int IdOrder);
        Orders GetOrderByFK(int fk);
        List<Orders> GetListOrder(int id);
    }
}
