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

        [HttpGet]
        public ActionResult ListRetaurants()
        {
            //get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var restoManager = new RestaurantManager(Configuration);
            var listResto = restoManager.GetRestaurants();

            return View(listResto);
        }


        public ActionResult ListAllDishesPerResto(int id)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetListDishes(id);
          

            return View(dish);
        }

    }
}