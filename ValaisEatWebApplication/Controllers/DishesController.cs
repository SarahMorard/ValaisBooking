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
    public class DishesController : Controller
    {
        private IConfiguration Configuration { get; }
        public DishesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //Get the italian dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetItalianDishes()                                                 
        {
            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();


            var dishList = new List<Dishes>();

           foreach(Dishes dishes in dish)
            {
                if(dishes.type == "Italian")
                {
                    dishList.Add(dishes); //Filling the new dishes list
                }
            }   
            return View(dishList);
        }

        //Get the Japanese dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetJapaneseDishes()
        {
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
            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();


            var dishList = new List<Dishes>();

            foreach (Dishes dishes in dish)
            {
                if (dishes.type == "Korean")
                {
                    dishList.Add(dishes); //Filling the new dishes list
                }
            }
            return View(dishList);
        }

        //Get the mexican dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetMexicanDishes()
        {
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
            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishes();

            return View(dish);
        }



        // Edit the selected dish
        public ActionResult Edit(int id)
        {

            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishId(id);

            return View(dish);
        }

        //post the new edited dish
        [HttpPost]
        public ActionResult Edit(DTO.Dishes d)
        {
            IDishesManager dishesManager = new DishesManager(Configuration);
            dishesManager.UpdateDish(d);

            return RedirectToAction(nameof(ListAllDishes)); 

        }

        // Details for one dish
        public ActionResult Details(int id)
        {
            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishId(id);

            return View(dish);
        }


        // Display template to create a new dish
        public ActionResult Create()
        {

            return View();
        }

        // Creating a new dish in the db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Dishes dish)
        {

            IDishesManager dishesManager = new DishesManager(Configuration);
            dishesManager.AddDish(dish);

            return RedirectToAction(nameof(ListAllDishes));


        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            IDishesManager dishesManager = new DishesManager(Configuration);
            var dish = dishesManager.GetDishId(id);

            return View(dish);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
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