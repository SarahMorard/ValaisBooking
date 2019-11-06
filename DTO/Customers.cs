﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Customers
    {
        public int idCustomers { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public int phone_number { get; set; }
        public string email { get; set; }
        public int city_id { get; set; }
        public int login_id { get; set; }
        public override string ToString()
        {
            return $"{idCustomers}|{firstName}|{lastName}|{address}|{phone_number}|{email}";
        }

    }
}
