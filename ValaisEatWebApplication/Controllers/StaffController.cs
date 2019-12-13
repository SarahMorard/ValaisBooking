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
    public class StaffController : Controller
    {
        private IConfiguration Configuration { get; }
        public StaffController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // create account for staff
        public ActionResult CreateAccountStaff(Staff s)
        {
            Staff staff= s;
            return View();
        }

       

        // List cities for the staff
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

        //Page of confirmation when the staff has usccessfully created their account
        public ActionResult Confirmation()
        {
            return View();
        }

        //Archive the order once it was delivered
        public ActionResult Archieve()
        {
            return View();
        }    
    }
}