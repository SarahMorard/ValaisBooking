using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order_Dishes
    {
        public int idOrder_Dishes { get; set; }
        public string status { get; set; }
        public int order_id { get; set; }
        public int login_id { get; set; }

        
        public override string ToString()
        {
            return $"{idOrder_Dishes}";
        }


    }
}
