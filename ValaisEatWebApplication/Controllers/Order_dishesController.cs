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
    public class Order_dishesController : Controller
    {
        private IConfiguration Configuration { get; }
        public Order_dishesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult Index()
        {

            return View();
        }

        // Get order dishes from ddb to display it
        [HttpGet]
        public ActionResult ListOrders()
        {
            var order_dishesManager = new Order_DishesManager(Configuration);
            var od = order_dishesManager.GetOrder_Dishes();

            var odList = new List<Order_Dishes>();

            foreach (Order_Dishes order_dishes in od)
            {
              
                odList.Add(order_dishes); 
              
            }

            return View(odList);
        }

        // GET: Order_dishes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order_dishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order_dishes/Create
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

        // GET: Order_dishes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order_dishes/Edit/5
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

        // GET: Order_dishes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order_dishes/Delete/5
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