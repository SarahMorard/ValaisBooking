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
            // Get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Managers for the actions of each table required to make the OrderDishesStaffMVC
            var ODManager = new Order_DishesManager(Configuration);
            var OManager = new OrdersManager(Configuration);
            var LManager = new LoginManager(Configuration);

            // Variables  
            int CurrentStaff = (int)HttpContext.Session.GetInt32("id"); // Get the id of the current user and save it inside a variable
            
            // Lists
            var ListODSModel = new List<OrderDishesStaffMVC>(); // The list we need to return at the end                
            var ListOD = ODManager.GetOD(CurrentStaff);         // List the dishesOrders according to the current loged staff   


            // Loop
            // Search the values for all the tables needed for the model
          
                foreach (Order_Dishes Od in ListOD)
                {
                    if (Od.status.Equals("waiting")) // if the status is "waiting" it means that the order dishes was not delivered so it must appear on the list
                    {
                        var O = OManager.GetOrderByFK(Od.order_id);       // Get one order according to the foreign key of order dishes
                        var L = LManager.GetLoginByFK(O.login_id);        // Get one login according to the rogeign key login of the order 
                        var ODSModelMVC = new OrderDishesStaffMVC();      // New var OrderDishesStaffMVC: new containt to put in the list each time

                        //create the model
                        ODSModelMVC.NoOrderDishes = Od.idOrder_Dishes;
                        ODSModelMVC.FistNameCustomer = L.firstName;
                        ODSModelMVC.LastNameCustomer = L.lastName;
                        ODSModelMVC.AddressDelivery = L.address;
                        ODSModelMVC.StatusDelivery = Od.status;
                        ODSModelMVC.TimeDelivery = O.time;
                        ODSModelMVC.TotalOrder = O.total;

                        ListODSModel.Add(ODSModelMVC); // Fill the list of the ODSModel 
                    }
                }        
            return View(ListODSModel);
        }

        // 1 list 2 edits
        // List the order dishes
        public ActionResult ListOD()
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int CurrentStaff = (int)HttpContext.Session.GetInt32("id"); // Get the id of the current user and save it inside a variable
            var ODManager = new Order_DishesManager(Configuration);
            var ListOD = ODManager.GetOD(CurrentStaff);                 // List the dishesOrders according to the current loged staff 

            return View(ListOD);
        }

        // Edit the selected dish
        public ActionResult Archive(int id)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IOrder_DishesManager ODManager = new Order_DishesManager(Configuration);
            var OD = ODManager.GetOrder_DishesId(id);       

            return View(OD);
        }

        //post the new edited dish
        [HttpPost]
        public ActionResult Archive(DTO.Order_Dishes od)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IOrder_DishesManager ODManager = new Order_DishesManager(Configuration);
            ODManager.UpdateOrder_Dishes(od);

           

            return RedirectToAction(nameof(DisplayOrderDishes));

        }
    }
}