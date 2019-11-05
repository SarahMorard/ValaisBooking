using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IOrderDB
    {
        List<Orders> GetOrders();
        Orders GetOrdersId(int idOrders);
        Orders AddOrders(Orders orders);
        int UpdateOrders(Orders orders);
        int DeleteOrders(int id);
    }
}
