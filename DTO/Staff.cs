using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Staff
    {
        public int idStaff { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int no_staff { get; set; }
        public string address { get; set; }
        public int phone_number { get; set; }
        public string email { get; set; }
        public int cities_id { get; set; }
        public int orders_id { get; set; }
        public int login_id { get; set; }
        public override string ToString()
        {
            return $"{idStaff}|{firstName}|{lastName}|{address}|{phone_number}|{email}|{cities_id}|{orders_id}|{login_id}";
        }
    }
}
