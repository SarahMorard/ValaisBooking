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
        public override string ToString()
        {
            return $"{idLogin}|{login}|{password}";
        }

    }
}
