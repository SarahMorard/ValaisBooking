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
    public class CustomersController : Controller
    {
        private IConfiguration Configuration { get; }
        public CustomersController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public ActionResult CreateAccountCustomer(Customers c)
        {
            Customers customer = c;
            return View();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // List cities for the customers
        public ActionResult Create()
        {
            var ctiyManager = new CitiesManager(Configuration);
            var city = ctiyManager.GetCities();

            var cities = new List<SelectListItem>();

            foreach (Cities c in city)
            {
                cities.Add(new SelectListItem { Value = c.idCities.ToString(), Text = c.name });
            }

            ViewBag.Cities = cities;
            return View();
        }

   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Customers customer, DTO.Login login)
        {
            
            ICustomersManager customerManager = new CustomersManager(Configuration);

            var loginManager = new LoginManager(Configuration);   
           

            try
            {
                customerManager.AddCustomer(customer);
                login.login = customer.email;
                login.password = null;
                var newLogin = loginManager.AddLogin(login);
                return RedirectToAction(nameof(Confirmation));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
               
            }
            

        }

        public ActionResult Confirmation()
        {
            return View();
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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