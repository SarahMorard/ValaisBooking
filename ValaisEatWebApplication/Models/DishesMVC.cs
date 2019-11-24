using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValaisEatWebApplication.Models
{
    public class DishesMVC
    {
        public int idDishes { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public override string ToString()

        {
            return $"{idDishes}|{name}|{price}";
        }
    }
}
