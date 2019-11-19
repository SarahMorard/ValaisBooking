using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValaisEatWebApplication.Models;

namespace ValaisEatWebApplication.Controllers
{
    public class RestaurantController : Controller
    {
        public ActionResult GetRestaurants()// right clikc on the method, chose list and cityhotel to create the view
                                       // model not in database
        {
            

            var restaurantList = new List<CityRestaurants> //change db here
            {
               
            };


            return View(restaurantList);
        }
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Restaurants r)
        {
            Restaurants restaurants = r;
            return View();
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
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

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
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

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
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