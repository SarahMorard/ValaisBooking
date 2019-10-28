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
        List<Order> GetOrder();
        Order GetOrderId(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
        int DeleteOrder(int IdOrder);
    }
}
