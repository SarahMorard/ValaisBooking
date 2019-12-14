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
    public class OrderDishesStaff
    {

        public Login CustomerModel { get; set; }
        public Dishes DishesModel { get; set; }
        public Orders OrderModel { get; set; }
        public Order_Dishes OdModel { get; set; }

        public OrderDishesStaff()
        {
            this.CustomerModel  = new Login();
            this.OrderModel     = new Orders();
            this.OdModel        = new Order_Dishes();
            this.DishesModel    = new Dishes();
        }
    }
}
