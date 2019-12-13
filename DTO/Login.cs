using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Login
    {
        public int idLogin { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public int city_id { get; set; }
        public override string ToString()
        {
            return $"{idLogin}|{login}|{password}";
        }

    }
}
