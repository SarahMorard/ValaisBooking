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

namespace ValaisEatWebApplication.Controllers
{
    public class Order_dishesController : Controller
    {
        private IConfiguration Configuration { get; }
        public Order_dishesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }      
       
    }
}