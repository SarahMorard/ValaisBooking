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

   
        //create a new customer
        [HttpPost]
        public ActionResult Create(DTO.Customers customer)
        {
            var customerManager = new CustomersManager(Configuration);

            try
            {
                customerManager.AddCustomer(customer);
                return RedirectToAction(nameof(Confirmation));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
               
            }
            

        }

        //if the account was successfully created, the customer will be redirected to this page
        public ActionResult Confirmation()
        {
            return View();
        }  

    }
}