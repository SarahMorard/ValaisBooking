using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ValaisEatWebApplication.Models;

namespace ValaisEatWebApplication.Controllers
{
   
    public class OrdersController : Controller
    {
        private IConfiguration Configuration { get; }
        public OrdersController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // Display the dish the customer want to order using the id of the dish as a parameter
        public IActionResult Index(int id)
        {
            // Get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            OrderViewModel orderVM = new OrderViewModel();      
            orderVM.idDishes = id;                                      // Put the id of the dish chosen by the customer in the model 
          
            orderVM.idLogin = (int)HttpContext.Session.GetInt32("id");  // Retrive the id of the current user customer and put it in the model


            return View(orderVM);                                       // Return the model with the previous parameters adde to it
        }

        // Put the chosen dishes infos in a session
        public ActionResult Create(int id) {

            // Get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            DishesManager dm = new DishesManager(Configuration);

            // Everything is saved in the session
            HttpContext.Session.SetInt32("IdDishes", id);                       // Set the id of the session according the id put in parameter that matches the dishes id 
            HttpContext.Session.SetString("NameOrder", dm.GetDishId(id).name);  // Set the name of the chosen dishes in the session

            string PriceOrderString = dm.GetDishId(id).price.ToString();        // Get the price of the chosen dish and cast it as a string in order to put it into a session
            HttpContext.Session.SetString("PriceOrder", PriceOrderString);      // Set the price of the chosen dish into a session

            ViewBag.Name = dm.GetDishId(id).name;                               // Put the name of the dish inside a ViewBag to display it in a the html Create page in the Orders View


            return View();
        }

        // Creation of the order made by the customer and order dishes assigned to a staff
        [HttpPost]
        public ActionResult Confirmation()
        {
            /*** ORDER ***/
            IOrderManager oMan = new OrdersManager(Configuration);
            OrderViewModel orderVM = new OrderViewModel();

            orderVM.idDishes = (int)HttpContext.Session.GetInt32("IdDishes");          // Retrieve the id of the dish chosen by the customer and put it in the model
            orderVM.name = HttpContext.Session.GetString("NameOrder");                 // Retrieve the name of the name chosen ba the customer     
            orderVM.price = double.Parse(HttpContext.Session.GetString("PriceOrder")); // Get the price, parse string price in double and put it into the model
            orderVM.idLogin = (int)HttpContext.Session.GetInt32("id");                 // Get the id of the person logged 

            string DeliveryTime = Request.Form["DeliveryTime"];                        // Retrieve the Html form request for the the time and put it into a string variable
            string Quantity = Request.Form["Quantity"];                                // Retrieve the Html form request for the quantity per dish the customer want to order
            orderVM.time = DeliveryTime;                                               // Put the quantity in the model
            orderVM.quantity = Int32.Parse(Quantity);                                  // Convert string in int


            // Create an order based on the view model
            DTO.Orders O = new Orders();                                               // Declare a new Order

            // Put all the variables retrives previously in the model inside the object order
            O.dishes_id = orderVM.idDishes;
            O.login_id = orderVM.idLogin;
            O.time = orderVM.time;
            O.quantity = orderVM.quantity;
            O.total = orderVM.quantity * orderVM.price;                                  // Calculate the total price
            double TQ = O.total;                                                         // Declare total
            string TQString = TQ.ToString();                                             // Convert total to string in order to put it into a session
                                                        
            DTO.Orders ORDER = oMan.AddOrders(O);                                        // Add order to the DB and put it into a variable to to use it for the next step


            /*** ORDER DISHES ***/
            IOrder_DishesManager ODMan = new Order_DishesManager(Configuration);
            ILoginManager loginManager = new LoginManager(Configuration);
            DTO.Order_Dishes OD = new Order_Dishes();                                     // Create a new object order dishes
            var ListLogin = loginManager.GetLogins();
            OD.order_id = ORDER.idOrders;                                                 // Set the foreign key with the primary key of the pevious order made
            OD.login_id = 1;


           /* foreach (Login log in ListLogin)                                               // Distinct StaffID Login
            {
                if (log.type.Equals("staff"))                                             
                {
                    int CountOrder = ODMan.Count_Order(log.idLogin);
                    
                    if (CountOrder > 5)                                                 //Verification of the number of order dishes per staff
                    {
                        break;
                    }
                    else
                    {
                        OD.login_id = log.idLogin;
                    }

                   
                }
            }
            */
                                                                      // Set login to 1 for a test
            

            HttpContext.Session.SetString("TotalOrder", TQString);                        // Put the model inside a session in order to use it late


            return RedirectToAction(nameof(TotalOrderDishes));                            // Redirection the a html page that show the customer how much his order costs

           
        }

        // Display the total amount of money the order cost for the customer
        public ActionResult TotalOrderDishes()
        {
            // Get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Total = HttpContext.Session.GetString("TotalOrder");        // Put the total inside a ViewBag to display it on the html page TotalOrderDishes in Orders View
            return View();
        }


        // List the customer orders
        [HttpGet]
        public ActionResult CustomerOrders()
        {
            // Get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int CurrentCustomer = (int)HttpContext.Session.GetInt32("id");     // Get the id of the current user and save it inside a variable

            var ordersMananger = new OrdersManager(Configuration);
            var listDishes = ordersMananger.GetListOrder(CurrentCustomer);     // Put all the order inside a list

            return View(listDishes);                                           // Return the list of customer orders
        }

        // Display the order selected by the customer who wan to cancel it
        public ActionResult CancelOrder(int id)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var OManager  = new OrdersManager(Configuration);
            var order = OManager.GetOrdersId(id);                               // Get the selected order by the customer

            return View(order);
        }

        // Delete the order selected by the customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelOrder(int id, IFormCollection collection)
        {
            // Get the session for the customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                var OManager = new OrdersManager(Configuration);
                OManager.DeleteOrders(id);                                      // Delete the selected order by the customer

                return RedirectToAction(nameof(CustomerOrders));                // Redirection to the list of orders for the customer
            }
            catch
            {
                return View();                                                  
            }
        }
    }
}