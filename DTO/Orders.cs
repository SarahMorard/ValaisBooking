using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Orders
    {
        public int idOrders { get; set; }
        public DateTime time { get; set; }
        public int quantity { get; set; }
        public int dishes_id { get; set; }
        public int login_id { get; set; }


        public override string ToString()
        {
            return $"{idOrders}";
        }

    }
}
