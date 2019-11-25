using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace ValaisEatWebApplication.Models
{
    public class DishesRestaurants
    {
        public string restaurant { get; set; }
        public List<Dishes> dishes { get; set; }
    }
}
