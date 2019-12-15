using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValaisEatWebApplication.Models
{
    public class OrderViewModel
    {
        //Dish
        public int idDishes { get; set; }
        public string name { get; set; }

        //Login
        public int idLogin { get; set; }

        //Orders
        public DateTime time { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }
    }
}
