using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace DAL
{
    public class CustomersDB
    {
        public IConfiguration Configuration { get; }
        public CustomersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
