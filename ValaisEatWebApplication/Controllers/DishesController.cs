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
    public class DishesController : Controller
    {
        private IConfiguration Configuration { get; }
        public DishesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Get the italian dishes from the bdd front office according to their type
        //Set the session so only users who are connected can access the italian menu page
        [HttpGet]
        public ActionResult GetItalianDishes()
        {
            //get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }


            IDishesManager dishesManager = new DishesManager(Configuration);

            var dish = dishesManager.GetDishes();
            var dishList = new List<Dishes>();  

            foreach (Dishes dishes in dish)
            {
                if (dishes.type == "Italian")
                {
                    dishList.Add(dishes); 
                }
            }

            return View(dishList);     
        }

        //Get the Japanese dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetJapaneseDishes()
        {
            //Get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();


            var dishList = new List<Dishes>();

            foreach (Dishes dishes in dish)
            {
                if (dishes.type == "Japanese")
                {
                    dishList.Add(dishes); //Filling the new dishes list
                }
            }
            return View(dishList);
        }

        //Get the Greek dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetGreekDishes()
        {

            //get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();


            var dishList = new List<Dishes>();

            foreach (Dishes dishes in dish)
            {
                if (dishes.type == "Greek")
                {
                    dishList.Add(dishes); //Filling the new dishes list
                }
            }
            return View(dishList);
        }

        //Get the indian dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetIndianDishes()
        {
            //get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();


            var dishList = new List<Dishes>();

            foreach (Dishes dishes in dish)
            {
                if (dishes.type == "Indian")
                {
                    dishList.Add(dishes); //Filling the new dishes list
                }
            }
            return View(dishList);
        }

        //Get the korean dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetKoreanDishes()
        {
            //get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();


            var dishList = new List<Dishes>();

            foreach (Dishes dishes in dish)
            {
                if (dishes.type == "Korean")
                {
                    dishList.Add(dishes); 
                }
            }
            return View(dishList);
        }

        //Get the mexican dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetMexicanDishes()
        {
            //get the session for customer
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();


            var dishList = new List<Dishes>();

            foreach (Dishes dishes in dish)
            {
                if (dishes.type == "Mexican")
                {
                    dishList.Add(dishes); //Filling the new dishes list
                }
            }
            return View(dishList);
        }


        //Display all the dishes on one page
        public ActionResult ListAllDishes()
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();

            return View(dish);
        }


        // Edit the selected dish
        public ActionResult Edit(int id)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishId(id);

            return View(dish);
        }

        //post the new edited dish
        [HttpPost]
        public ActionResult Edit(DTO.Dishes d)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            dishesManager.UpdateDish(d);

            return RedirectToAction(nameof(ListAllDishes));

        }

        // Details for one dish
        public ActionResult Details(int id)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishId(id);

            return View(dish);
        }


        // Display template to create a new dish
        public ActionResult Create()
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var restoManager = new RestaurantManager(Configuration);
            var restaurants = restoManager.GetRestaurants();

            var resto = new List<SelectListItem>(); // Create a selected list with all the city in the db for the client to chose

            foreach (Restaurants r in restaurants)
            {
                resto.Add(new SelectListItem { Value = r.idRestaurant.ToString(), Text = r.name }); // Add the cities to a SelectListItem ot diplay them for the customer
            }

            ViewBag.Cities = resto; // Put the list in the ViewBag

            return View();
        }

        // Creating a new dish in the db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Dishes dish)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            dishesManager.AddDish(dish);

            return RedirectToAction(nameof(ListAllDishes));


        }

        // delete dish
        public ActionResult Delete(int id)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishId(id);

            return View(dish);
        }

        // delete dish
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                IDishesManager dishesManager = new DishesManager(Configuration);
                dishesManager.DeleteDish(id);

                return RedirectToAction(nameof(ListAllDishes));
            }
            catch
            {
                return View();
            }
        }
    }
}