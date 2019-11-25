using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dishes
    {
        public int idDishes { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public double price { get; set; }
       
        public override string ToString()
        
        {
            return $"{idDishes}|{name}|{type}|{price}";
        }

    }
}
