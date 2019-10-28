using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order_Dishes
    {
        public int idOrder_Dishes { get; set; }
        public int quantity { get; set; }
        public int orders_id { get; set; }
        public int customers_id { get; set; }
        public int dishes_id { get; set; }
        public override string ToString()
        {
            return $"{idOrder_Dishes}|{quantity}|{orders_id}|{customers_id}|{dishes_id}";
        }


    }
}
