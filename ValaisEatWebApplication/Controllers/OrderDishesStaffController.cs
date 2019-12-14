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

        //Display the order dishes according to the staff their belong to 
        public ActionResult DisplayOrderDishes()
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //managers for the actions of each table required to make the OrderDishesStaffMVC
            var ODManager = new Order_DishesManager(Configuration);
            var OManager = new OrdersManager(Configuration);
            var LManager = new LoginManager(Configuration);
            var DMananger = new DishesManager(Configuration);

            //get the id of the current user and save it inside a variable
            int CurrentStaff = (int)HttpContext.Session.GetInt32("id");

            //lists
            //put the order_dishes indise a list for the current user staff
            var ListOD = ODManager.GetOD(CurrentStaff);
            var List

           

            
            
            //status of Order_Dishes




            return View(ListOD);
        }

        


        //update status
        public ActionResult UpdateStatus()
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}