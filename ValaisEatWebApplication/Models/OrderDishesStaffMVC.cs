using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValaisEatWebApplication.Models;
using BLL;
using Microsoft.Extensions.Configuration;
using System.IO;
using DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ValaisEatWebApplication.Models
{
    public class OrderDishesStaffMVC
    {
        public int NoOrderDishes { get; set; }
        public string LastNameCustomer { get; set; }
        public string FistNameCustomer { get; set; }
        public string AddressDelivery { get; set; }
        public DateTime TimeDelivery { get; set; }
        public int PhoneCustomer { get; set; }
        public string StatusDelivery { get; set; }
        public double TotalOrder { get; set; }

        public OrderDishesStaffMVC()
        {
            this.LastNameCustomer   = "";
            this.FistNameCustomer   = "";
            this.AddressDelivery    = "";
            this.TimeDelivery       = DateTime.Now;
            this.PhoneCustomer      = 0;
            this.StatusDelivery     = "";
            this.TotalOrder         = 0;

        }


    }
}
