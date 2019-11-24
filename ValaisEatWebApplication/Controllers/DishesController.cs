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
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
          .Build();


        //Get the italian dishes from the bdd front office according to their type
        [HttpGet]
        public ActionResult GetItalianDishes()                                                 
        {      
            var dishesManager = new DishesManager(Configuration);
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
            var dishesManager = new DishesManager(Configuration);
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
            var dishesManager = new DishesManager(Configuration);
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
            var dishesManager = new DishesManager(Configuration);
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
            var dishesManager = new DishesManager(Configuration);
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
            var dishesManager = new DishesManager(Configuration);
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

        public ActionResult listResto(int id)
        {
            var resto = new Restaurants();

            var restaurants = new List<SelectListItem>
            {
                new SelectListItem {Value = "1", Text=resto.name},
                new SelectListItem {Value = "2", Text=resto.name},
                new SelectListItem {Value = "3", Text=resto.name}, //ask the bll for info in the db
            };
            ViewBag.Restaurants = restaurants;
            ViewBag.Selected = 2;
            return View();
        }

        // GET: Dishes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dishes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Dishes d)
        {
            Dishes dishes = d;
            return View();
        }

        // GET: Dishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dishes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dishes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dishes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dishes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dishes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}