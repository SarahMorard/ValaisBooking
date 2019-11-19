using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValaisEatWebApplication.Models
{
    public class Dishes
    {
        public int idDishes { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public DateTime time { get; set; }
        public int Status_id { get; set; }

        public override string ToString()

        {
            return $"{idDishes}|{name}|{price}|{time}|{Status_id}";
        }
    }
}
