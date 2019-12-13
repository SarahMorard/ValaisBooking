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

namespace ValaisEatWebApplication.Models
{
    public class OrderDishesMVC
    {
        public string loginName { get; set; }
        public string loginAddress { get; set; }
        public string orderPrice { get; set; }
        public string status { get; set; }

    }
}
