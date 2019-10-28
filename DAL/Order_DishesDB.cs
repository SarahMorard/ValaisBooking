using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class Order_DishesDB
    {
        public IConfiguration Configuration { get; }
        public Order_DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
