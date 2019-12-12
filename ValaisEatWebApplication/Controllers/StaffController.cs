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


        //create a login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Staff staff, DTO.Login login)
        {

            IStaffManager staffManager = new StaffManager(Configuration);

            var loginManager = new LoginManager(Configuration);


            try
            {
                staffManager.AddStaff(staff);
                login.login = staff.email;
                login.password = null;
                var newLogin = loginManager.AddLogin(login);
                return RedirectToAction(nameof(Confirmation));
            }
            catch
            {
                return RedirectToAction(nameof(Create));

            }


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

        

        //get the list of order assigned to the staff
        [HttpGet]
        public ActionResult ListOrderCustomer()
        {
            //get the session for staff
            if (HttpContext.Session.GetString("staffname") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            /*foreach Login l in log
            * if login.id == l.id
            * l.id == new var
            * get id of costumer who is loged
            */
            var orderDishesManager = new Order_DishesManager(Configuration);

            var listOrderDishes = orderDishesManager.GetOrder_Dishes();

            string UserID = User.Identity.Name;

            return View(listOrderDishes);
        }
    }
}