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
    public class LoginController : Controller
    {
        private IConfiguration Configuration { get; }
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //Connection page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //login for staff member and customers
        [HttpPost]
        public IActionResult Index(Login l)
        {
            var loginManager = new LoginManager(Configuration);
            Login login = loginManager.IsUserValid(l.login, l.password); //verify if the login is valid then return the valid login

            if (login != null)
            {
                //log to customer account according to the value "customer"
                if (login.type.Equals("customer")) //verify if the type match the value "customer"
                {
                    HttpContext.Session.SetString("username", login.login);
                    HttpContext.Session.SetInt32("id", login.idLogin); //set login of the customer for this session
                    return RedirectToAction(nameof(Success)); //redirection to a page that tell the customer that he has been logged
                }
                else
                {
                    HttpContext.Session.SetString("staffname", login.login); 
                    HttpContext.Session.SetInt32("id", login.idLogin); //set login of the staff for this session
                    return RedirectToAction(nameof(SuccessStaff)); //redirection to a page that tell the staff that he has been logged
                }
            }
            else
            {
                return View();
            }

        }

        //Decconnection from the session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        // List cities for the customers
        public ActionResult Create()
        {
            var ctiyManager = new CitiesManager(Configuration);
            var city = ctiyManager.GetCities();

            var cities = new List<SelectListItem>(); // Create a selected list with all the city in the db for the client to chose

            foreach (Cities c in city)
            {
                cities.Add(new SelectListItem { Value = c.idCities.ToString(), Text = c.name }); // Add the cities to a SelectListItem ot diplay them for the customer
            }

            ViewBag.Cities = cities; // Put the list in the ViewBag
            return View();
        }


        //create a new customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            var loginManager = new LoginManager(Configuration);

            loginManager.AddLogin(login);
            //return RedirectToAction("Login", "Create");
        
            return RedirectToAction(nameof(Success));



        }


        // If the account was successfully created, the customer will be redirected to this page
        public ActionResult Confirmation()
        {
            return View();
        }

        // If the login customer was successful, redirection to page Success
        public IActionResult Success()
        {
            return View();
        }

        // If the login staff was successful, redirection to page Success
        public IActionResult SuccessStaff()
        {
            return View();
        }
    }
}