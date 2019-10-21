using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Order_Dishes
    {
        public int idOrder_Dishes { get; set; }
        public int quantity { get; set; }
        public int orders_id { get; set; }
        public int customers_id { get; set; }
        public int dishes_id { get; set; }


    }
}
