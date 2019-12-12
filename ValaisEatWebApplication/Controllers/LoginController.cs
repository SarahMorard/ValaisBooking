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

namespace WebApplication2.Controllers
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
            Login login = loginManager.IsUserValid(l.login, l.password) ;         

            if (login != null)
            {
               
                if (login.type.Equals("customer"))
                {
                    HttpContext.Session.SetString("username", login.login);
                    HttpContext.Session.SetInt32("username", login.idLogin);
                    return RedirectToAction(nameof(Success));
                }
                else
                {
                    HttpContext.Session.SetString("staffname", login.login);
                    HttpContext.Session.SetInt32("staffname", login.idLogin);
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

            return View();
        }


        //create a new login
        [HttpPost]
        public ActionResult Create(DTO.Login login)
        {
            var loginManager = new LoginManager(Configuration);
            var customerManager = new CustomersManager(Configuration);

            //add the login foreign key
            int idFK = 0;

            var listLogin = loginManager.GetLogin();

            foreach (Login l in listLogin)
            {
                if (l.idLogin > idFK)
                {
                    idFK = login.idLogin;
                }
            }
            try
            {
                loginManager.AddLogin(login);
                //customerManager.UpdateCustomer();
                return RedirectToAction("Confirmation", "Customers");
            }
            catch
            {
                return RedirectToAction(nameof(Create));

            }


        }
    }
  }