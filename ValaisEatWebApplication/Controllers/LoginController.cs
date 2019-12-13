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


        //if the login customer was successful, redirection to page Success
        public IActionResult Success()
        {
            return View();
        }

        //if the login staff was successful, redirection to page Success
        public IActionResult SuccessStaff()
        {
            return View();
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
            Login login = loginManager.IsUserValid(l.login, l.password);

            if (login != null)
            {

                if (login.type.Equals("customer"))
                {
                    HttpContext.Session.SetString("username", login.login);
                    HttpContext.Session.SetInt32("id", login.idLogin);
                    return RedirectToAction(nameof(Success));
                }
                else
                {
                    HttpContext.Session.SetString("staffname", login.login);
                    HttpContext.Session.SetInt32("id", login.idLogin);
                    return RedirectToAction(nameof(SuccessStaff));
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
        public ActionResult Create(DTO.Login login)
        {
            var loginManager = new LoginManager(Configuration);

            try
            {
                loginManager.AddLogin(login);
                return RedirectToAction("Login", "Create");
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