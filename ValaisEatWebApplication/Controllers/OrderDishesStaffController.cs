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

namespace ValaisEatWebApplication.Controllers
{
    public class OrderDishesStaffController : Controller
    {
        private IConfiguration Configuration { get; }
        public OrderDishesStaffController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        //list the order assigned to the staff who is loged
         public ActionResult listDishesPerStaff()
        {
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int idCurrentStaff = (int)HttpContext.Session.GetInt32("id");

            //manager
            var orderDishesManager = new Order_DishesManager(Configuration);
            var loginManager = new LoginManager(Configuration);

            //lists
            var listOrders = orderDishesManager.GetOrder_Dishes();
            var listLogins = loginManager.GetLogins(); 

            foreach (Order)
            {

            }

            return View();
        }
    }
}