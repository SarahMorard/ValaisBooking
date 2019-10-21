using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Cities
    {
        public int idCities { get; set; }
        public int zip_code { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{idCities}|{zip_code}|{name}";
        }
    }
}
