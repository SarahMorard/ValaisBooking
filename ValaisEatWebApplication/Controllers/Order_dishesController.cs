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

namespace ValaisEatWebApplication.Controllers
{
    public class Order_dishesController : Controller
    {
        private IConfiguration Configuration { get; }
        public Order_dishesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public ActionResult ListOrderCustomer(Order_Dishes order_Dishes)
        {
            //get the session for customer
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var orderDishesManager = new Order_DishesManager(Configuration);

            var listOrderDishes = orderDishesManager.GetOrder_Dishes();

         

            return View(listOrderDishes);
        }

        [HttpGet]
        public ActionResult List()
        {
  
            //get the session for customer
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var orderDishesManager = new Order_DishesManager(Configuration);

            var listOrderDishes = orderDishesManager.GetOrder_Dishes();



            return View(listOrderDishes);
        }
    }
}