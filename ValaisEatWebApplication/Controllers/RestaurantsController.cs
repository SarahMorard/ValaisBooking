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
    public class RestaurantsController : Controller
    {
        private IConfiguration Configuration { get; }
        public RestaurantsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // List the restaurants available on the website 
        [HttpGet]
        public ActionResult ListRetaurants()
        {
            // Get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var restoManager = new RestaurantManager(Configuration);
            var listResto = restoManager.GetRestaurants();          // Put all the restaurant in a list

            return View(listResto);                                 // Return the list of restaurants
        }

        // List the dishes according to the restaurant they belong to
        public ActionResult ListAllDishesPerResto(int id)
        {
            // Get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetListDishes(id);                     // Get the dish selected by the customer
          

            return View(dish);                                              // Return the dish selected by the customer
        }
    }
}