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
        private ILoginManager LoginManager { get; }
        public LoginController(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }


        //if the login was successful, redirection to page Success
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult SuccessStaff()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            Login login = LoginManager.IsUserValid(l.login, l.password) ;
            /*foreach Login l in log
             * if login.id == l.id
             * l.id == new var
             * get id of costumer who is loged
           */

            if (login != null)
            {
                if (login.type.Equals("customer"))
                {
                    HttpContext.Session.SetString("username", l.login); 
                 
                    return RedirectToAction(nameof(Success));
                }
                else
                {
                    HttpContext.Session.SetString("staffname", l.login);
                    return RedirectToAction(nameof(SuccessStaff));
                }
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
  }