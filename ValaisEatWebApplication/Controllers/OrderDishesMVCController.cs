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
    public class OrderDishesMVCController : Controller
    {
        private IConfiguration Configuration { get; }
        public OrderDishesMVCController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult ListDishes()
        {
            return View();
        }

        //get the list of order assigned to the staff

        public ActionResult ListOrderCustomer()
        {
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //values
            OrderDishesMVC odMVC = new OrderDishesMVC();
            int idCurrentUSer = (int)HttpContext.Session.GetInt32("id");

            //manager
            var ordersMananger = new OrdersManager(Configuration);
            var loginManager = new LoginManager(Configuration);
            var dishesMananger = new DishesManager(Configuration);

            //lists
            var listOrderDishes = new List<OrderDishesMVC>();
            var listStatus = new List<string>();

            var listOrders = ordersMananger.GetOrders();
            var listLogin = loginManager.GetLogins();
            var listDishes = dishesMananger.GetDishes();

            //foreach lists
            //values in order
            foreach (Orders od in listOrders)
            {
                if(idCurrentUSer == od.login_id)
                {
                    odMVC.status = od.status;
                    
                }
            }

            foreach (Orders od in listOrders)
            {
                if (idCurrentUSer == od.login_id)
                {
                    
                }
            }




            return View(listOrderDishes);
        }
    }
}