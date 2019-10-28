using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Orders
    {
        public int idOrders { get; set; }
        public int Status_id { get; set; }
        public override string ToString()
        {
            return $"{idOrders}|{Status_id}";
        }

    }
}
