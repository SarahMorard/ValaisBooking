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
    public class OrderDishesStaffMVCController : Controller
    {
        private IConfiguration Configuration { get; }
        public OrderDishesStaffMVCController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Display the order dishes according to the staff their belong to 
        [HttpGet]
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

            //variables  
            int CurrentStaff = (int)HttpContext.Session.GetInt32("id"); //get the id of the current user and save it inside a variable
            
            //lists
            var ListODSModel = new List<OrderDishesStaffMVC>(); //the list we need to return at the end                
            var ListOD = ODManager.GetOD(CurrentStaff);         //List the dishesOrders according to the current loged staff
           

            // Search the values for all the tables needed for the model
            foreach (Order_Dishes Od in ListOD)
            {
                var O = OManager.GetOrderByFK(Od.order_id);       //get one order according to the foreign key of order dishes
                var L = LManager.GetLoginByFK(O.login_id);        //get one login according to the rogeign key login of the order 
                var ODSModelMVC = new OrderDishesStaffMVC();      // new var OrderDishesStaffMVC: new containt to put in the list each time

                //create the model
                ODSModelMVC.FistNameCustomer = L.firstName;
                ODSModelMVC.LastNameCustomer = L.lastName;
                ODSModelMVC.AddressDelivery  = L.address;
                ODSModelMVC.StatusDelivery   = Od.status;
                ODSModelMVC.TimeDelivery     = O.time;
                ODSModelMVC.TotalOrder       = O.total;

                ListODSModel.Add(ODSModelMVC); // Fill the list of the ODSModel            
            }
            return View(ListODSModel);
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