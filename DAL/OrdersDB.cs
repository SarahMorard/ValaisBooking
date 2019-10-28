using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class OrdersDB
    {
        public IConfiguration Configuration { get; }
        public OrdersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
