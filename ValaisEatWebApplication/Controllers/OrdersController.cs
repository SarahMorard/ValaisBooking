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
        //implémentation auto des id externe 
        public IActionResult Index(int idDishes)
        {
            //get the session for customer
            if (HttpContext.Session.GetString("ursername") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            OrderViewModel orderVM = new OrderViewModel();
            orderVM.idDishes = idDishes;
            orderVM.idLogin = (int)HttpContext.Session.GetInt32("id");


            return View(orderVM);
        }
        public ActionResult Create(OrderViewModel orderVM)
        {
            try
            {
                // Set Total
                // TODO: Add insert logic here
                IOrderManager oMan = new OrdersManager(Configuration);

               
                
                //Implementation de mon Order
                DTO.Orders O = new Orders();  // New Order

                O.dishes_id = orderVM.idDishes;
                O.login_id = orderVM.idLogin;
                O.time = orderVM.time;
                O.quantity = orderVM.quantity;
                O.total = orderVM.total*orderVM.price;  // Total calculated
                //Mettre dans la base de donée 
                oMan.AddOrders(O);
                
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}