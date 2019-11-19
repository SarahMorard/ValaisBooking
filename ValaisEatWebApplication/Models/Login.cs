using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValaisEatWebApplication.Models
{
    public class Login
    {
        public int idLogin { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return $"{idLogin}|{login}|{password}";
        }
    }
}
