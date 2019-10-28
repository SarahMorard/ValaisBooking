﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurants
    {
        public int idRestaurant { get; set; }
        public string name { get; set; }
        public int city_id { get; set; }
        public int dishes_id { get; set; }
        public override string ToString()
        {
            return $"{idRestaurant}|{name}|{city_id}|{dishes_id}";
        }
    }
}
