using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValaisEatWebApplication.Models
{
    public class CityRestaurants
    {
        public string city { get; set; }

        public List<Restaurants> restaurants { get; set; }
    }
}
