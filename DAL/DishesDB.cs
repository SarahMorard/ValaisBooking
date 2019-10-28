using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace DAL
{
    public class DishesDB
    {
        public IConfiguration Configuration { get; }
        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
